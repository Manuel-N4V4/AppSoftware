using AppSoftware.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSoftware
{
    public partial class frmApartados : Form
    {
        string rol;

        public frmApartados(string rol)
        {
            InitializeComponent();
            this.rol = rol;

            btnEntradas.Enabled = false;
            btnSalidas.Enabled = false;
            btnProveedores.Enabled = false;
            btnUsuarios.Enabled = false;
            btnProductos.Enabled = false;

            switch (this.rol)
            {
                case "Administrador":
                    btnEntradas.Enabled = true;
                    btnSalidas.Enabled = true;
                    btnProveedores.Enabled = true;
                    btnUsuarios.Enabled = true;
                    btnProductos.Enabled = true;
                    break;
                case "Gerente":
                    btnProductos.Enabled = true;
                    btnProveedores.Enabled = true;
                    btnUsuarios.Enabled = true;
                    break;
                case "Vendedor":
                    btnEntradas.Enabled = true;
                    btnSalidas.Enabled = true;
                    break;
                case "Compras":
                    btnProveedores.Enabled = true;
                    btnProductos.Enabled = true;
                    break;
                case "Almacenista":
                    btnProductos.Enabled = true;
                    break;
            }
        }

        public frmApartados()
        {
            InitializeComponent();
        }

        private void frmApartados_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEntradas entradas = new frmEntradas();
            entradas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSalidasInventario salidasInventario = new frmSalidasInventario();
            salidasInventario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmUsuarioscs usuarioscs = new frmUsuarioscs();
            usuarioscs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            frmInicio inicio = new frmInicio();
            inicio.Show();
        }
    }
}
