using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_
{
    public partial class Alumnos_PagPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["usuario"] as string))
            {
                if (Session["tipo"] != "alumno")
                {
                    Server.Transfer("Profesor/Profesor.aspx", true);
                }
                
            }
            else
            {
                Response.Redirect("../Inicio.aspx");
            }

        }
    }
}