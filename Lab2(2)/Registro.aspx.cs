using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBManager;
using EmailServices;

namespace Lab2_2_
{
    public partial class Registro : System.Web.UI.Page
    {
        DBManager.DBManager db = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
            if (!HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).Contains("localhost"))
            {
                lblDev.Visible = false;
            }
            lblDev.Text = db.Conectar();
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int NumConf = (int)(rnd.Next() * 9000000) + 1000000;
            bool insertado = db.InsertarUsuario(txtboxEmail.Text,txtboxNomYApe.Text,txtboxApellidos.Text,NumConf,false,ddRol.Text,txtboxPsw.Text);
            if (insertado)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Usuario insertado correctamente! En breve recibiras un correo electronico para confirmar tu cuenta')", true);
                EmailServices.EmailServices emailServices = new EmailServices.EmailServices();
                emailServices.EnviarEmail(txtboxEmail.Text, "Confirmar cuenta", "<div><h1>Hola " + txtboxEmail.Text + ".</h1></div><div><h2>¡Confirme su cuenta a través de este enlace!</h2></div><a href='" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Confirmar.aspx?email=" + txtboxEmail.Text + "&cod=" + NumConf.ToString() + "'>Aqui</a>");
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario no insertado, consulte al administrador')", true);
            }
            
        }
    }
}