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
    public partial class frmUsuarioscs : Form
    {
        Conexion con = new Conexion();
        public frmUsuarioscs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDatosUsuario datosUsuario = new frmDatosUsuario();
            datosUsuario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool eliminado = con.ejecutarComando($"DELETE FROM Usuario WHERE id = {txtIdentificador.Text}");

            if (eliminado)
            {
                MessageBox.Show("Usuario eliminado correctamente", "Sistema");
                dgvUsuarios.DataSource = con.ejecutarConsulta("SELECT * FROM Usuario").Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = con.ejecutarConsulta($"Select * from Usuario where identificador = {txtIdentificador.Text}");

            if(ds != null)
            {
                dgvUsuarios.DataSource = ds.Tables[0];
            }
        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvUsuarios.Rows[e.RowIndex];

            frmDatosUsuario du = new frmDatosUsuario(Convert.ToInt32(row.Cells[0].Value),
                row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());

            du.ShowDialog();
        }

        private void frmUsuarioscs_Load(object sender, EventArgs e)
        {

        }
    }
}
