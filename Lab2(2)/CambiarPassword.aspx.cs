using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdditionalServices;
using DBManager;
namespace Lab2_2_
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DBManager.DBManager dBManager = new DBManager.DBManager();
        string cod;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
            email = Request.QueryString["email"];
            cod = Request.QueryString["cod"];
            if (email != null && cod != null && email.Length != 0 && cod.Length != 0)
            {
                DIVMandarMail.Visible = false;
                DIVCambiarPasw.Visible = true;
            }
            else {
                DIVCambiarPasw.Visible = false;
                DIVMandarMail.Visible = true;
            }
        }
        protected void btnMandarMail_Click(object sender, EventArgs e)
        {
            dBManager.Conectar();
            AdditionalServices.AdditionalServices emailServices = new AdditionalServices.AdditionalServices();
            int cod = dBManager.GetCodigo(txtboxEmail.Text);
            if (cod != -1) {
                emailServices.EnviarEmail(txtboxEmail.Text,"Cambiar contraseña", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/CambiarPassword.aspx?email=" +txtboxEmail.Text +"&cod="+cod);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Email mandado correctamente! En breve recibiras un correo electronico para confirmar tu cuenta')", true);
            }

            
        }

        protected void btnCambiarPsw_Click(object sender, EventArgs e)
        {
            dBManager.Conectar();
            int dbCod = dBManager.GetCodigo(email);
            if (dbCod == int.Parse(cod))
            {
                if (dBManager.SetPassword(email, txtboxPsw.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Contraseña cambiada correctamente!')", true);

                }
            }
        }
    }
}