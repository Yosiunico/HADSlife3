﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBManager;
using AdditionalServices;

namespace Lab2_2_
{
    public partial class Registro : System.Web.UI.Page
    {
        es.ehusw.Matriculas mt = new es.ehusw.Matriculas();
        DBManager.DBManager db = new DBManager.DBManager();
        AdditionalServices.AdditionalServices emailServices = new AdditionalServices.AdditionalServices();
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
            String pass = emailServices.Encripta(txtboxPsw.Text, emailServices.Invertir(txtboxEmail.Text));
            bool insertado = db.InsertarUsuario(txtboxEmail.Text,txtboxNomYApe.Text,txtboxApellidos.Text,NumConf,false,ddRol.Text,pass);
            if (insertado)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Usuario insertado correctamente! En breve recibiras un correo electronico para confirmar tu cuenta')", true);
                emailServices.EnviarEmail(txtboxEmail.Text, "Confirmar cuenta", "<div><h1>Hola " + txtboxEmail.Text + ".</h1></div><div><h2>¡Confirme su cuenta a través de este enlace!</h2></div><a href='" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Confirmar.aspx?email=" + txtboxEmail.Text + "&cod=" + NumConf.ToString() + "'>Aqui</a>");
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario no insertado, consulte al administrador')", true);
            }
            
        }

        protected void txtboxPsw_TextChanged(object sender, EventArgs e)
        {
            FuerzaPass fuerzaPass = new FuerzaPass();

            int fuerza= fuerzaPass.CheckStrength(txtboxPsw.Text.ToString());
            labelFuerza.Text = "Fortaleza: "+ fuerza + "|| Minimo tiene que ser 2";
            if (fuerza < 3)
            {
                btnRegistro.Enabled = false;
                labelFuerza.Text = "Fortaleza: " + fuerza + "|| Minimo tiene que ser 2. Intenta añadiendo letras(mayusculas y minusculas), numeros y caracteres especiales. La longitud tambien deberia sobrepasar el 12";
            }
            else {
                btnRegistro.Enabled = true;
                labelFuerza.Text = "Fortaleza: " + fuerza;
            }
        }

        protected void txtboxEmail_TextChanged(object sender, EventArgs e)
        {
            if(mt.comprobar(txtboxEmail.Text.ToString()) == "NO") {
                Label7.ForeColor = System.Drawing.Color.Red;
                Label7.Text = "El email introducido no está matriculado.";
                btnRegistro.Enabled = false;
            } else {
                Label7.ForeColor = System.Drawing.Color.Green;
                Label7.Text = "El email introducido está matriculado.";
                btnRegistro.Enabled = true;
            }
        }
    }
}