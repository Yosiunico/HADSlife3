using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBManager;

namespace Lab2_2_.Profesor
{
    public partial class Profesor : System.Web.UI.Page
    {
        private int cont= 0;
        /*private int */
        private DBManager.DBManager dBManager = new DBManager.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(Session["usuario"] as string))
            {
                if (Session["tipo"].ToString() != "profesor")
                {
                    Server.Transfer("~/Alumno/Alumno.aspx", true);
                }
            }
            else
            {
                Response.Redirect("../Inicio.aspx");
            }*/

            if(!Session["tipo"].ToString().Equals("coordinador"))
            {
                HyperLink6.Enabled = false;
                HyperLink7.Enabled = false;
                HyperLink8.Enabled = false;
            }

            dBManager.Conectar();

        }


        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            //cont++;
            //Label5.Text = "actualizado" + cont.ToString();
            //System.Data.DataTable dt1 = dBManager.getAlumnosConectados().Tables[0];
            //System.Data.DataView dv1 = new System.Data.DataView(dt1);
            //GridView1.DataSource = dv1;
            //System.Data.DataTable dt2 = dBManager.getAlumnosConectados().Tables[0];
            //System.Data.DataView dv2 = new System.Data.DataView(dt2);
            //GridView1.DataSource = dv2;
            //GridView1.DataBind();
            //GridView2.DataBind();
            //Label4.Text = "USUARIOS LOGEADOS: " + GridView1.Rows.Count.ToString() + " Alumno/s y " + GridView2.Rows.Count.ToString() + " Profe/s";
            /*Timer1.Interval = */
            //Label5.Text = System.DateTime.Today.ToString();
        }

       

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label6.Text = System.DateTime.Now.ToString();
        }
    }
}