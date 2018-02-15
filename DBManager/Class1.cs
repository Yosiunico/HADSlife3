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
        private System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();

        public string Conectar()
        {
            try
            {
                conexion.ConnectionString= "Server=tcp:hads2020.database.windows.net,1433;Initial Catalog=HADS20;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conexion.Open();
            }
            catch(Exception ex)
            {
                return "ERROR DE LA CONEXIÓN" + ex.Message;
            }
            return "CONEXION OK";
        }
    }
}
