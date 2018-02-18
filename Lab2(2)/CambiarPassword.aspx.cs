using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailServices;
using DBManager;
namespace Lab2_2_
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DBManager.DBManager dBManager = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
        }
        protected void btnMandarMail_Click(object sender, EventArgs e)
        {
            dBManager.Conectar();
            EmailServices.EmailServices emailServices = new EmailServices.EmailServices();
            int cod = dBManager.GetCodigo(txtboxEmail.Text);
            if (cod != -1) {
                emailServices.EnviarEmail(txtboxEmail.Text,"Cambiar contraseña", "http://localhost:50887/CambiarPassword.aspx?email="+txtboxEmail.Text +"&cod="+cod);
            }

            
        }
    }
}