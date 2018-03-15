using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_.Alumno
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DBManager.DBManager dBManager = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).Contains("localhost"))
            {
                log.Visible = false;
            }
            log.Text = Request.QueryString["cod"];
            txtBoxTarea.Text = Request.QueryString["cod"];
            txtBoxUsuario.Text = Session["usuario"].ToString();
            txtBoxEst.Text = Request.QueryString["horas"];
            if (!IsPostBack)
            {
                 System.Data.DataTable dt = dBManager.getTareasAlumno(Session["usuario"].ToString()).Tables[0];
                GVTareas.DataSource = dt;
                GVTareas.DataBind();

            }

        }
    }
}