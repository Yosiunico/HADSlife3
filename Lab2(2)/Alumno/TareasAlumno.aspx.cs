using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBManager;

namespace Lab2_2_.Alumno
{
    public partial class TareasAlumno : System.Web.UI.Page
    {
        private DBManager.DBManager dBManager = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).Contains("localhost"))
            {
                log.Visible = false;
            }

            dBManager.Conectar();
            List<String> asignaturas = dBManager.getAsignaturasAlumno(Session["usuario"].ToString());
            DDAsignaturas.DataSource = asignaturas;
            DDAsignaturas.DataBind();

            GVAsignaturas.DataSource = dBManager.getTareasGenericas(Session["usuario"].ToString()).Tables[0];
            GVAsignaturas.DataBind();
        }
    }
}