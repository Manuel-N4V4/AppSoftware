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
    public partial class frmSalidasInventario : Form
    {
        Conexion con = new Conexion();
        public frmSalidasInventario()
        {
            InitializeComponent();
            cbMotivo.Items.Add("Defectuoso");
            cbMotivo.Items.Add("Incompleto");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            string sqlInsertDev = "INSERT INTO DevolucionInventario (clvProducto, producto, cantidad, fecha, motivo) " +
                                  $"VALUES ('{txtID.Text}', '{txtProducto.Text}', {nudCantidad.Value}, '{fecha}', '{cbMotivo.Text}')";

            if (con.ejecutarComando(sqlInsertDev))
            {
                string sqlRestarStock = $"UPDATE Almacenamiento SET cantidad = cantidad - {nudCantidad.Value} " +
                                        $"WHERE clvProducto = '{txtID.Text}'";

                con.ejecutarComando(sqlRestarStock);

                MessageBox.Show("Devolución por defecto registrada. El stock ha sido descontado.", "J.A.R.V.I.S");

                DataSet ds = con.ejecutarConsulta("SELECT * FROM Almacenamiento");
                if (ds != null)
                {
                    dgvVentasInventario.DataSource = ds.Tables[0];
                }
            }
            else
            {
                MessageBox.Show("Error al procesar la devolución.", "Sistema");
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            bool val = con.ejecutarComando(
                "INSERT INTO SalidasInventario (clvProducto, producto, cantidad, fecha, motivo, marca) " +
                $"VALUES ('{txtID.Text}', '{txtProducto.Text}', {nudCantidad.Value}, '{fecha}', '{cbMotivo.Text}', '{txtMarca.Text}')"
            );

            if (val)
            {
                con.ejecutarComando($"UPDATE Almacenamiento SET cantidad = cantidad - {nudCantidad.Value} WHERE clvProducto = '{txtID.Text}'");
                MessageBox.Show("Venta registrada y stock actualizado", "Sistema");

                DataSet dt = con.ejecutarConsulta("SELECT * FROM SalidasInventario");
                if (dt != null) dgvVentasInventario.DataSource = dt.Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = con.ejecutarConsulta($"SELECT * FROM SalidasInventario WHERE clvProducto = '{txtID.Text}' OR marca = '{txtID.Text}'");
            if (ds != null)
            {
                dgvVentasInventario.DataSource = ds.Tables[0];
            }
        }

        private void dgvVentasInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvVentasInventario.Rows[e.RowIndex];

                string cveProd = Convert.ToString(row.Cells[0].Value);
                string producto = Convert.ToString(row.Cells[1].Value);
                int cantidad = Convert.ToInt32(row.Cells[2].Value);
                string fecha = Convert.ToString(row.Cells[3].Value);
                string motivo = Convert.ToString(row.Cells[4].Value);
                string marca = Convert.ToString(row.Cells[5].Value);

                txtID.Text = cveProd;
                txtProducto.Text = producto;
                nudCantidad.Value = cantidad;
                dtpFecha.Value = Convert.ToDateTime(fecha);
                cbMotivo.Text = motivo;
                txtMarca.Text = marca;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(rbSalidas.Checked)
            {
                DataSet ds = con.ejecutarConsulta("SELECT * FROM SalidasInventario");
                if (ds != null)
                {
                    dgvVentasInventario.DataSource = ds.Tables[0];
                }
            }
        }

        private void rbDevoluciones_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDevoluciones.Checked)
            {
                DataSet ds = con.ejecutarConsulta("SELECT * FROM DevolucionInventario");
                if (ds != null)
                {
                    dgvVentasInventario.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
