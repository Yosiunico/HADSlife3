using EmailServices;
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (db.ExisteEmail(TextBox1.Text))
            {
                if (db.UsuarioValidado(TextBox1.Text))
                {
                    if (db.SesionValida(TextBox1.Text, TextBox2.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Log in correcto! ¡Bienvenido " + TextBox1.Text + "!')", true);
                        Session["usuario"] = TextBox1.Text;
                        Server.Transfer("Home.aspx", true);
                    } else {
                        Label4.Text = "La contraseña es incorrecta, por favor, inténtelo de nuevo.";
                    }
                } else {
                    Label4.Text = "El usuario no ha sido validado.";
                }
            } else {
                Label4.Text = "El email que ha introducido no es válido ni está registrado.";
            }

        }
    }
}