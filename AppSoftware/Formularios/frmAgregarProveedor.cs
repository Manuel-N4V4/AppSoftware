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
    public partial class frmAgregarProveedor : Form
    {
        Conexion con = new Conexion();
        public frmAgregarProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Proveedores (idProveedor, nombreEmpresa, nombreContacto, email, direccion, telefono) " +
                 $"VALUES ('{txtIdProveedor.Text}', '{txtNomEmpresa.Text}', '{txtNomProv.Text}', '{txtEmail.Text}', '{txtDireccion.Text}', '{txtTelefono.Text}')";

            if (con.ejecutarComando(sql))
            {
                MessageBox.Show("Proveedor agregado correctamente", "Sistema");
            }
            else
            {
                MessageBox.Show("Error al agregar el proveedor", "Sistema");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
