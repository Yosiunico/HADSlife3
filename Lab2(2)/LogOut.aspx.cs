using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DBManager.DBManager db = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            db.Conectar();
            db.borrarConectado(Session["usuario"].ToString());

            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            Server.Transfer("Inicio.aspx", true);
        }
    }
}