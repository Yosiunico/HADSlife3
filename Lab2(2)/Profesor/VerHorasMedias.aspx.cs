using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_.Profesor
{
    public partial class VerHorasMedias : System.Web.UI.Page
    {
        net.azurewebsites.hadslife2.CoordinatorServices cs = new net.azurewebsites.hadslife2.CoordinatorServices();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label4.Text = "Horas medias estimadas por los alumnos: " + cs.ObtenerDedicación(DropDownList1.Text.ToString());
        }


    }
}