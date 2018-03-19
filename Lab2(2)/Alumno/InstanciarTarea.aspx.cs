using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_.Alumno
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlCommandBuilder cb;
        private SqlDataAdapter da;
        private System.Data.DataSet ds;
        System.Data.DataTable dt;
        private DBManager.DBManager dBManager = new DBManager.DBManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["in"] = null;
            }
            log.Text += "PostBack" + IsPostBack + " -- " + IsCallback;
            if (!string.IsNullOrEmpty(Session["usuario"] as string))
            {
                if (Session["tipo"].ToString() != "alumno")
                {
                    Server.Transfer("../Profesor/Profesor.aspx", true);
                }
            }
            else
            {
                Response.Redirect("../Inicio.aspx");
            }

            dBManager.Conectar();
            if (!HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).Contains("localhost"))
            {
                log.Visible = false;
            }
            log.Text += Session["cod"].ToString();
            txtBoxTarea.Text = Session["cod"].ToString();
            txtBoxUsuario.Text = Session["usuario"].ToString();
            txtBoxEst.Text = Session["horas"].ToString();
            da = dBManager.getTareasAlumno(Session["usuario"].ToString());
            ds = new System.Data.DataSet();
            da.Fill(ds, "EstudiantesTareas");
            cb = new SqlCommandBuilder(da);
            dt = ds.Tables[0];
            GVTareas.DataSource = dt;
            GVTareas.DataBind();
            if (IsPostBack)
            {
                Button1.Enabled = false;
                txtBoxReales.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["Email"] = txtBoxUsuario.Text.ToString();
                dr["CodTarea"] = txtBoxTarea.Text.ToString();
                dr["HEstimadas"] = txtBoxEst.Text.ToString();
                dr["HReales"] = txtBoxReales.Text.ToString();
                dt.Rows.Add(dr);
                da.UpdateCommand = cb.GetUpdateCommand();
                da.Update(ds, "EstudiantesTareas");
                GVTareas.DataSource = dt;
                GVTareas.DataBind();
            }
            else
            {
                log.Text = "null";
            }
        }
    }
}