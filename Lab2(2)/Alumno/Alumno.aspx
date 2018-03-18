<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="Lab2_2_.Alumnos_PagPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 404px;
        }
        .auto-style3 {
            height: 26px;
            width: 158px;
            background-color: #40B5C1;
        }
        .auto-style4 {
            width: 158px;
            height: 24px;
            background-color: #40B5C1;
        }
        .auto-style5 {
            width: 100%;
            height: 358px;
        }
        .auto-style6 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="auto-style5">
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumno.aspx">Tareas Genericas</asp:HyperLink>
                    </td>
                    <td rowspan="3" style="align-content; text-align: center; text-indent: 0px; background-color: #3599A5;">
                        <asp:Label ID="Label1" runat="server" Text="Gestión Web de Tareas-Dedicación" CssClass="auto-style6"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style6" Text="Alumnos"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:HyperLink ID="HyperLink2" runat="server">Tareas propias</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
