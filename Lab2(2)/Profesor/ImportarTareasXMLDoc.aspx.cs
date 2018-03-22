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
    public partial class ImportarTareasXMLDoc : System.Web.UI.Page
    {
        private DBManager.DBManager dBManager;
        private SqlCommandBuilder cb;
        private DataTable dt;
        private SqlDataAdapter da;
        private DataSet ds;

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

            //Button1.Attributes.Add("onclick", "return window.confirm('¿Desea rellenar la base de datos con " + DropDownList2.SelectedValue.ToString() + ".xml?');");
            dBManager = new DBManager.DBManager();
            dBManager.Conectar();
            ds = new DataSet();
            da = dBManager.getTareasGenericas();
            da.Fill(ds, "TareasGenericas");
            cb = new SqlCommandBuilder(da);
            dt = ds.Tables[0];
        }

        protected void asignatura_SelIndexChan(object sender, EventArgs e)
        {
            Xml2.DocumentSource = Server.MapPath("/App_Data/" + DropDownList2.SelectedValue.ToString() + ".xml");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Server.MapPath("/App_Data/" + DropDownList2.SelectedValue.ToString() + ".xml"));
            XmlNodeList tareas = xd.GetElementsByTagName("tarea");            int n = tareas.Count;            string tareasrep = "";            for (int i = 0; i < n; i++)
            {
                XmlNode tarea = tareas[i];

                if (!dBManager.tareaRepetida(tarea.Attributes["codigo"].ToString()))
                {
                    DataRow dr = dt.NewRow();
                    dr["Codigo"] = tarea.Attributes["codigo"].ToString();
                    dr["Descripcion"] = tarea.ChildNodes[0].Value.ToString();
                    dr["CodAsig"] = DropDownList2.SelectedValue.ToString();
                    dr["HEstimadas"] = int.Parse(tarea.ChildNodes[1].Value);
                    dr["Explotacion"] = bool.Parse(tarea.ChildNodes[2].Value);
                    dr["TipoTarea"] = tarea.ChildNodes[3].Value.ToString();
                    dt.Rows.Add(dr);
                }
                else
                {
                    tareasrep += '-' + tarea.Attributes["codigo"].ToString() + Environment.NewLine;
                    log.Text += tarea.Attributes["codigo"].ToString();
                }

            }

            da.UpdateCommand = cb.GetUpdateCommand();
            da.Update(ds, "TareasGenericas");
            da.Update(dt);

            if (!string.IsNullOrEmpty(tareasrep as string))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Una o varias tareas han sido omitidas debido a que el código estaba repetido. Las tareas omitidas son las siguientes: " + Environment.NewLine + tareasrep + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Las tareas se han añadido exitosamente!');", true);
            }
        }
    }
}