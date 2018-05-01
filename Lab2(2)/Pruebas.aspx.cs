using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_
{
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FuerzaPass fuerzaPass = new FuerzaPass();
            Label1.Text = "Fuerza => " + fuerzaPass.CheckStrength("Oh12345234561256715%&56");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            FuerzaPass fuerzaPass = new FuerzaPass();
           
            Label1.Text = "Fuerza => " + fuerzaPass.CheckStrength(TextBox1.Text.ToString());
        }
    }
}