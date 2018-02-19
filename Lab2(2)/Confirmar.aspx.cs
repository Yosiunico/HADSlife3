using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBManager;

namespace Lab2_2_
{
    public partial class Confirmar : System.Web.UI.Page
    {
        DBManager.DBManager db = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
            string email = Request.QueryString["email"];
            string cod = Request.QueryString["cod"];

            Label1.Text = "Confirmar";

            db.Conectar();
            if (email != null && cod != null && email.Length != 0 && cod.Length != 0)
            {
                bool conf = db.ConfirmarCuenta(email, int.Parse(cod));
                if (conf)
                {
                    ErrorLabel.Text = "Cuenta confirmada correctamente!!";

                }
                else
                {
                    ErrorLabel.Text = "Error al confirmar la cuenta";
                    Div1.Visible = false;
                    ErrorLabel.Visible = true;
                }
            }
            else {
                ErrorLabel.Text = "Error al confirmar la cuenta";
                Div1.Visible = false;
                ErrorLabel.Visible = true;

            }
        }
    }
}