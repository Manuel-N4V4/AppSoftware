using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace AppSoftware
{
    internal class Conexion
    {
        MySqlConnection con;

        public MySqlConnection conexion()
        {
            try
            {
                string cadenaConexion = "server=localhost;port=3306;database=appsoftware;user=root;password=manuel1234;";
                con = new MySqlConnection(cadenaConexion);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                return null;
            }
        }

        public void desconectar()
        {
            if (con != null)
            {
                con.Close();
            }
        }

        public bool ejecutarComando(string comando)
        {
            try
            {
                conexion();
                MySqlCommand com = new MySqlCommand(comando, con);
                com.ExecuteNonQuery();
                desconectar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando: " + ex.Message);
                return false;
            }
        }

        public DataSet ejecutarConsulta(string consulta)
        {
            DataSet ds = new DataSet();
            try
            {
                conexion();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);
                da.Fill(ds);
                desconectar();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message);
                return null;
            }
        }
    }
}
