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
    public partial class frmAgregar : Form
    {
        Conexion con = new Conexion();
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            string sql = "INSERT INTO Almacenamiento (clvProducto, categoria, nombre, cantidad, marca, fecha, proveedor) " +
                         $"VALUES ('{txtClvProducto.Text}', '{cbCategoria.Text}', '{txtNombreProd.Text}', {nudCantidad.Value}, '{cbMarca.Text}', '{fecha}', '{txtProveedor.Text}')";

            if (con.ejecutarComando(sql))
            {
                MessageBox.Show("Producto agregado correctamente", "Sistema");
            }
            else
            {
                MessageBox.Show("Error al agregar el producto", "Sistema");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
