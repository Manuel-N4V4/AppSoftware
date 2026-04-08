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
    public partial class Form1 : Form
    {
        Conexion con = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataSet val = con.ejecutarConsulta($"SELECT * FROM Almacenamiento WHERE clvProducto = '{txtclvProducto.Text}'");
            if (val != null)
            {
                dgvAlmacenamiento.DataSource = val.Tables[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtclvProducto.Text))
                return;

            bool val = con.ejecutarComando($"DELETE FROM Almacenamiento WHERE clvProducto = '{txtclvProducto.Text}'");
            if (val)
            {
                MessageBox.Show("Producto eliminado correctamente");
                DataSet ds = con.ejecutarConsulta("SELECT * FROM Almacenamiento");
                dgvAlmacenamiento.DataSource = ds.Tables[0];
            }
        }
    }
}
