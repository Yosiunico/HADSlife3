using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab2_2_
{
    /// <summary>
    /// Otorga funcionalidades al rol coordinador de la aplicación.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class CoordinatorServices : System.Web.Services.WebService
    {

        [WebMethod]
        public int ObtenerDedicación(string asignatura)
        {
            DBManager.DBManager db = new DBManager.DBManager();
            db.Conectar();
            int hmedias = db.getHorasMediasPorAsignatura(asignatura);
            db.CerrarConexion();
            return hmedias;
        }
    }
}
