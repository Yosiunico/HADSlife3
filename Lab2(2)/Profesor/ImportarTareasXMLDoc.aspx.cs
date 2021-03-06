﻿using System;
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
            xd.Load(Server.MapPath("../App_Data/" + DropDownList2.SelectedValue.ToString() + ".xml"));
            XmlNodeList tareas = xd.GetElementsByTagName("tarea");
            int n = tareas.Count;
            string tareasrep = "";
            for (int i = 0; i < n; i++)
            {

                if (!dBManager.tareaRepetida(tareas[i].Attributes["codigo"].Value.ToString()))
                {   
                    DataRow dr = dt.NewRow();
                    dr["Codigo"] = tareas[i].Attributes["codigo"].Value.ToString();
                    dr["Descripcion"] = tareas[i].ChildNodes[0].InnerText.ToString();
                    dr["CodAsig"] = DropDownList2.SelectedValue.ToString();
                    dr["HEstimadas"] = int.Parse(tareas[i].ChildNodes[1].InnerText);
                    dr["Explotacion"] = bool.Parse(tareas[i].ChildNodes[2].InnerText);
                    dr["TipoTarea"] = tareas[i].ChildNodes[3].InnerText.ToString();
                    dt.Rows.Add(dr);
                    
                }
                else
                {
                    if (i < n - 2) {
                        tareasrep = tareasrep + tareas[i].Attributes["codigo"].Value.ToString() + ", ";
                    } else if (i == n - 2) {
                        tareasrep = tareasrep + tareas[i].Attributes["codigo"].Value.ToString() + " y ";
                    } else if (i == n - 1) {
                        tareasrep = tareasrep + tareas[i].Attributes["codigo"].Value.ToString() + ".";
                    }
                   
                }

            }
                
                da.UpdateCommand = cb.GetUpdateCommand();
                da.Update(ds, "TareasGenericas");
                da.Update(dt);
                
            
            if (tareasrep != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Tareas insertadas! Advertencia - Las siguientes tareas no se han insertado al tener código repetido: " + tareasrep + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Las tareas se han añadido exitosamente!');", true);
            }
        }
    }
}