using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBManager;

namespace Lab2_2_
{
    public partial class Registro : System.Web.UI.Page
    {
        DBManager.DBManager db = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
            lblDev.Text = db.Conectar();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Usuario insertado correctamente!')", true);
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int NumConf = (int)(rnd.Next() * 9000000) + 1000000;
            db.InsertarUsuario(txtboxEmail.Text,txtboxNomYApe.Text,txtboxApellidos.Text,NumConf,false,ddRol.Text,txtboxPsw.Text);
        }
    }
}