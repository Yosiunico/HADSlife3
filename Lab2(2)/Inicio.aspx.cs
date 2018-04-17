using AdditionalServices;
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
                    AdditionalServices.AdditionalServices additional = new AdditionalServices.AdditionalServices();
                    String pass = additional.Encripta(TextBox2.Text, additional.Invertir(TextBox1.Text));
                    
                    if (db.SesionValida(TextBox1.Text, pass))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Log in correcto! ¡Bienvenido " + TextBox1.Text + "!')", true);
                        Session["usuario"] = TextBox1.Text;

                        if (!Session["usuario"].ToString().Equals("vadillo@ehu.es")) {
                            if (db.isAlumno(TextBox1.Text.ToString()))
                            {
                                Session["tipo"] = "alumno";
                                System.Web.Security.FormsAuthentication.SetAuthCookie(Session["tipo"].ToString(), true);
                                Server.Transfer("Alumno/Alumno.aspx", true);
                            }
                            else
                            {
                                Session["tipo"] = "profesor";
                                System.Web.Security.FormsAuthentication.SetAuthCookie(Session["tipo"].ToString(), true);
                                Server.Transfer("Profesor/Profesor.aspx", true); // Aqui tiene que ir a la dirección del profesor  :D
                            }
                        } else
                        {
                            Session["tipo"] = Session["usuario"].ToString();
                            System.Web.Security.FormsAuthentication.SetAuthCookie(Session["tipo"].ToString(), true);
                            Server.Transfer("Profesor/Profesor.aspx", true);
                        }


                    }
                    else
                    {
                        Label4.Text = "La contraseña es incorrecta, por favor, inténtelo de nuevo.";
                    }
                }
                else
                {
                    Label4.Text = "El usuario no ha sido validado.";
                }
            }
            else
            {
                Label4.Text = "El email que ha introducido no es válido ni está registrado.";
            }
        }
    }
}