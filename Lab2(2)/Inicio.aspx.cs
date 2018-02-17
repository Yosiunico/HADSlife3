using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBManager.DBManager db = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
            db.Conectar();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Usuario insertado correctamente!')", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}