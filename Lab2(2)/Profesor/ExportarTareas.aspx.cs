using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Lab2_2_.Profesor
{
    public partial class ExportarTareas : System.Web.UI.Page
    {
        private DBManager.DBManager dBManager;
        private SqlCommandBuilder cb;
        private DataTable dt;
        private SqlDataAdapter da;
        private DataSet ds;

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            DataView dv = Session["dataview"] as DataView;
            dv.RowFilter = "CodAsig ='" + DropDownList2.Text.ToString() + "'";
            GridView1.DataSource = dv;
            GridView1.DataBind();
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["usuario"] as string))
            {
                if (Session["tipo"].ToString() != "profesor")
                {
                    Server.Transfer("~/Alumno/Alumno.aspx", true);
                }
            }
            else
            {
                Response.Redirect("../Inicio.aspx");
            }
            if (!IsPostBack)
            {
                dBManager = new DBManager.DBManager();
                dBManager.Conectar();
                ds = new DataSet();
                da = dBManager.getTareasGenericas();
                da.Fill(ds, "TareasGenericas");
                cb = new SqlCommandBuilder(da);
                dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                GridView1.DataSource = dv;
                GridView1.DataBind();
                Session["dataview"] = dv;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataView dv = Session["dataview"] as DataView;
            XmlWriter writer = XmlWriter.Create(Server.MapPath("../App_Data/" + DropDownList2.SelectedValue.ToString() + ".xml").ToString());
            writer.WriteStartDocument();
            writer.WriteStartElement("tareas");
            foreach (DataRowView rowView in dv)
            {
                DataRow row = rowView.Row;
                writer.WriteStartElement("tarea");
                writer.WriteAttributeString("codigo", row["Codigo"].ToString());
                writer.WriteElementString("descripcion", row["Descripcion"].ToString());
                writer.WriteElementString("hestimadas", row["HEstimadas"].ToString());
                writer.WriteElementString("explotacion", row["Explotacion"].ToString());
                writer.WriteElementString("tipotarea", row["TipoTarea"].ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Las tareas se han exportado exitosamente!');", true);

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = Session["dataview"] as DataView;
            dv.RowFilter = "CodAsig ='" + DropDownList2.Text.ToString() + "'";
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    }
}