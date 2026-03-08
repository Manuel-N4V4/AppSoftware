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
        public frmInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmApartados apartados = new frmApartados();
            apartados.Show();
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
