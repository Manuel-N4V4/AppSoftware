using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSoftware.Formularios
{
    public partial class frmEntradas : Form
    {
        Conexion con = new Conexion();
        public frmEntradas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            string sql = $"INSERT INTO Entradas (idEntradas, producto, marca, cantidad, proveedor, fecha) " +
                         $"VALUES ({txtID.Text}, '{txtProducto.Text}', '{txtMarca.Text}', {nudCantidad.Value}, '{txtProveedor.Text}', '{fecha}')";

            bool val = con.ejecutarComando(sql);

            if (val)
            {
                MessageBox.Show("Entrada registrada correctamente");
                ActualizarGrid();
            }
        }

        private void dgvEntradas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvEntradas.Rows[e.RowIndex];

                txtID.Text = Convert.ToString(row.Cells[0].Value);
                txtProducto.Text = Convert.ToString(row.Cells[1].Value);
                txtMarca.Text = Convert.ToString(row.Cells[2].Value);
                nudCantidad.Value = Convert.ToDecimal(row.Cells[3].Value);
                txtProveedor.Text = Convert.ToString(row.Cells[4].Value);
                dtpFecha.Value = Convert.ToDateTime(row.Cells[5].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            string sql = $"UPDATE Entradas SET " +
                         $"producto = '{txtProducto.Text}', " +
                         $"marca = '{txtMarca.Text}', " +
                         $"cantidad = {nudCantidad.Value}, " +
                         $"proveedor = '{txtProveedor.Text}', " +
                         $"fecha = '{fecha}' " +
                         $"WHERE idEntradas = {txtID.Text}";

            bool var = con.ejecutarComando(sql);

            if (var)
            {
                MessageBox.Show("Entrada actualizada correctamente");
                ActualizarGrid();
            }
        }

        private void ActualizarGrid()
        {
            DataSet ds = con.ejecutarConsulta("SELECT * FROM Entradas");
            if (ds != null)
            {
                dgvEntradas.DataSource = ds.Tables[0];
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                string sql = $"DELETE FROM Entradas WHERE idEntradas = {txtID.Text}";
                bool var = con.ejecutarComando(sql);
                if (var)
                {
                    MessageBox.Show("Entrada eliminada correctamente");
                    ActualizarGrid();
                }
            }
        }
    }
}
