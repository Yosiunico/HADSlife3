using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    public class DBManager
    {
        private System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand comando;

        public string Conectar()
        {
            try
            {
                conexion.ConnectionString= "Server=tcp:hads2020.database.windows.net,1433;Initial Catalog=HADS20;Persist Security Info=False;User ID=hads20;Password=Hadslife3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conexion.Open();
            }
            catch(Exception ex)
            {
                return "ERROR DE LA CONEXIÓN" + ex.Message;
            }
            return "CONEXION OK";
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }

        public string InsertarUsuario(string email, string nombre, string apellidos,int numConfir, bool confirmado, string tipo, string pass)
        {
            comando = new System.Data.SqlClient.SqlCommand("insert into Usuarios (email,nombre,apellidos,numconfir,confirmado,tipo,pass) values (@email,@nombre,@apellidos,@numconfir,@confirmado,@tipo,@pass)", conexion);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@apellidos", apellidos);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@numconfir", numConfir);
            comando.Parameters.AddWithValue("@confirmado", confirmado);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@pass", pass);
            int numRegs;
            try
            {
                numRegs = comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return numRegs + "registro(s) insertado(s) en la BD" ;

        }
    }
}
