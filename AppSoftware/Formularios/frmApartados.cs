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
        }
    }
}
