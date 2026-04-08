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
    public partial class frmInicio : Form
    {
        Conexion con = new Conexion();
        public frmInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Usuario WHERE usuario = '{txtUsuario.Text}' AND contraseña = '{txtContraseña.Text}'";
            DataSet ds = con.ejecutarConsulta(sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string rolUsuario = ds.Tables[0].Rows[0]["rol"].ToString();
                MessageBox.Show($"Bienvenido a casa. Todos los sistemas de inventario están en línea. Nivel de acceso: {rolUsuario}", "J.A.R.V.I.S");

                frmApartados apartados = new frmApartados(rolUsuario);
                this.Hide();
                apartados.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Sistema");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\jmanu\\source\\repos\\AppSoftware\\AppSoftware\\images.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
