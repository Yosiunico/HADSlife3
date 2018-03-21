using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_.Profesor
{
    public partial class ImportarTareasXMLDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(Session["usuario"] as string))
            {
                if (Session["tipo"].ToString() != "profesor")
                {
                    Server.Transfer("~/Alumno/Alumno.aspx", true);
                }
            }
            else
            {
                Response.Redirect("../Inicio.aspx");
            }
        }

        protected void asignatura_SelIndexChan(object sender, EventArgs e)
        {
            Xml2.DocumentSource = Server.MapPath("/App_Data/" + DropDownList2.SelectedValue + ".xml");
        }


    }
}