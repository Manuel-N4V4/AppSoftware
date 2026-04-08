using System;
using System.Windows.Forms;

namespace AppSoftware.Formularios
{
    public partial class frmDatosUsuario : Form
    {
        Conexion con = new Conexion();
        bool band = false;
        int idOriginal = 0;
        
        public frmDatosUsuario()
        {
            InitializeComponent();
            cbRol.Items.Add("Administrador");
            cbRol.Items.Add("Gerente");
            cbRol.Items.Add("Vendedor");
            cbRol.Items.Add("Compras");
            cbRol.Items.Add("Almacenista");
        }

        public frmDatosUsuario(int clve, string usuario, string constraseña, string rol)
        {
            InitializeComponent();

            this.idOriginal = clve;
            txtIdUsuario.Text = clve.ToString();
            txtUsuario.Text = usuario;
            txtContraseña.Text = constraseña;
            cbRol.Text = rol;
            band = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (band == false)
            {
                bool val = con.ejecutarComando(
                    $"INSERT INTO Usuario (id, usuario, contraseña, rol) " +
                    $"VALUES ({txtIdUsuario.Text}, '{txtUsuario.Text}', '{txtContraseña.Text}', '{cbRol.Text}')"
                );

                if (val)
                {
                    MessageBox.Show("Usuario agregado correctamente", "Sistema");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar el usuario", "Sistema");
                }
            }
            else
            {
                bool val = con.ejecutarComando(
                    $"UPDATE Usuario SET " +
                    $"id = {txtIdUsuario.Text}, " +
                    $"usuario = '{txtUsuario.Text}', " +
                    $"contraseña = '{txtContraseña.Text}', " +
                    $"rol = '{cbRol.Text}' " +
                    $"WHERE id = {this.idOriginal}"
                );
                if (val)
                {
                    MessageBox.Show("Usuario actualizado correctamente", "Sistema");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el usuario", "Sistema");
                }
            }
        }
    }
}