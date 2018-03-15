<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="Lab2_2_.Alumno.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 499px;
        }
        .auto-style2 {
            width: 118px;
            background-color: #C0C0C0;
        }
        .auto-style3 {
            font-size: x-large;
            vertical-align: center;
        }
        .auto-style4 {
            vertical-align: baseline;
            background-color: #C0C0C0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:HyperLink ID="HyperLink1" runat="server">Cerrar Sesión</asp:HyperLink>
                    </td>
                    <td class="auto-style4" rowspan="2" style="vertical-align: middle; text-align: center;">
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Alumnos"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Gestión de tareas genéricas"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
            <br />
            Seleccionar asignatura (solo se muestran aquellas en las que está matriculado)<br />
            <br />
            <asp:DropDownList ID="DDAsignaturas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDAsignaturas_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="GVAsignaturas" runat="server" OnSelectedIndexChanged="GVAsignaturas_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Instanciar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="log" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
