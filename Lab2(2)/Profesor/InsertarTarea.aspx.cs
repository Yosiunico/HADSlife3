using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_2_.Profesor
{
    public partial class InsertarTarea : System.Web.UI.Page
    {
        private DBManager.DBManager dBManager;
        private SqlCommandBuilder cb;
        private DataTable dt;
        private SqlDataAdapter da;
        private DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; //Para evitar errores que surgían en validación.
            if (!string.IsNullOrEmpty(Session["usuario"] as string))
            {
                if (Session["tipo"] != "profesor")
                {
                    Server.Transfer("Alumno/Alumno.aspx", true);
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }

            dBManager = new DBManager.DBManager();
            dBManager.Conectar();
            ds = new DataSet();
            da = dBManager.getTareasGenericas();
            da.Fill(ds, "TareasGenericas");
            cb = new SqlCommandBuilder(da);
            dt = ds.Tables[0];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(!dBManager.tareaRepetida(TextBox1.Text.ToString())) {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = TextBox1.Text.ToString();
                dr["Descripcion"] = TextBox3.Text.ToString();
                dr["CodAsig"] = DropDownList1.Text.ToString();
                dr["HEstimadas"] = TextBox2.Text.ToString();
                dr["Explotacion"] = false;
                dr["TipoTarea"] = DropDownList2.Text.ToString();
                dt.Rows.Add(dr);
                da.UpdateCommand = cb.GetUpdateCommand();
                da.Update(ds, "TareasGenericas");
                da.Update(dt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Tarea añadida con éxito!')", true);
            } else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La tarea que intenta añadir tiene un código ya utilizado.')", true);
            }

        }
    }
}