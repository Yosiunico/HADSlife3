using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public bool UsuarioValidado(string email)
        {
            comando = new System.Data.SqlClient.SqlCommand("select confirmado from Usuarios where email=@email", conexion);
            comando.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            bool confirmado = (bool) reader["confirmado"];
            reader.Close();
            return confirmado;
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

        public bool InsertarUsuario(string email, string nombre, string apellidos,int numConfir, bool confirmado, string tipo, string pass)
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
                return false;
            }

            return true;

        }

        public bool SesionValida(string email, string pass)
        {
            comando = new System.Data.SqlClient.SqlCommand("select pass from Usuarios where email=@email", conexion);
            comando.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            string passcomp = reader["pass"].ToString();
            reader.Close();
            return passcomp.Equals(pass);
        }

        public bool ExisteEmail(string email)
        {   
            comando = new System.Data.SqlClient.SqlCommand("select email from Usuarios where email=@email", conexion);
            comando.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = comando.ExecuteReader();
            bool existe = reader.Read();
            reader.Close();
            return existe;
        }

        public bool ConfirmarCuenta(string email, int cod) {
            comando = new System.Data.SqlClient.SqlCommand("SELECT numconfir FROM Usuarios WHERE email=@email", conexion);
            comando.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            int dbCod = int.Parse(reader["numconfir"].ToString());
            reader.Close();

            comando = new System.Data.SqlClient.SqlCommand("UPDATE usuarios SET confirmado = 1 WHERE email=@email", conexion);
            comando.Parameters.AddWithValue("@email", email);
            comando.ExecuteNonQuery();
            return dbCod.Equals(cod);
        }

        public int GetCodigo(string email) {
            if (ExisteEmail(email))
            {
                comando = new System.Data.SqlClient.SqlCommand("SELECT numconfir FROM usuarios WHERE email=@email",conexion);
                comando.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                int cod = int.Parse(reader["numconfir"].ToString());
                reader.Close();
                return cod;
            }
            else {
                return -1;
            }
        }
        public bool SetPassword(string email, string passw){
            if (ExisteEmail(email))
            {
                comando = new System.Data.SqlClient.SqlCommand("UPDATE usuarios SET pass=@pass WHERE email=@email", conexion);
                comando.Parameters.AddWithValue("@pass", passw);
                comando.Parameters.AddWithValue("@email", email);
                int numFilas = comando.ExecuteNonQuery();
                return numFilas == 1;
            }
            else
            {
                return false;
            }
        }

        public List<String> getAsignaturasAlumno(string alumno)
        {
            comando = new System.Data.SqlClient.SqlCommand("select GC.codigoasig from (EstudiantesGrupo as EG inner join Usuarios as U on EG.Email = U.email) inner join GruposClase as GC on EG.Grupo = GC.codigo where U.email = @email;", conexion);
            comando.Parameters.AddWithValue("@email", alumno);
            SqlDataReader reader =  comando.ExecuteReader();
            List<String> asignaturas = new List<string>();
            while (reader.Read())
            {
                asignaturas.Add(reader["codigoasig"].ToString());
            }
            reader.Close();
            return asignaturas;
        }
        public System.Data.DataSet getTareasGenericas(string alumno)
        {
            SqlDataAdapter da = new SqlDataAdapter("select TG1.Codigo, TG1.Descripcion, TG1.HEstimadas, TG1.TipoTarea, GC.codigoasig from(EstudiantesGrupo as EG inner join GruposClase as GC on EG.Grupo = GC.codigo) inner join TareasGenericas as TG1 on GC.codigoasig = TG1.CodAsig where EG.Email = '"+ alumno +"' and not exists(SELECT * FROM EstudiantesTareas WHERE CodTarea = TG1.Codigo and Email = EG.Email)", conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "TareasGenericas");
            return ds; 
        }

    }
}
