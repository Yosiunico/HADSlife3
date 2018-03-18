<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Lab2_2_.Profesor.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


        .auto-style5 {
            width: 100%;
            height: 574px;
            margin-bottom: 0px;
        }
        .auto-style7 {
            width: 140px;
            height: 22px;
        }
        .auto-style6 {
            font-size: xx-large;
        }
        .auto-style10 {
            height: 3px;
            width: 140px;
        }
        .auto-style9 {
            height: 9px;
            width: 140px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
            <table class="auto-style5">
                <tr>
                    <td class="auto-style7" style="background-color: #CCCC00">
                        <asp:HyperLink ID="HyperLink1" runat="server">Asignaturas</asp:HyperLink>
                    </td>
                    <td rowspan="6" style="align-content; text-align: center; text-indent: 0px; background-color: #CCCCCC;">
                        <asp:Label ID="Label1" runat="server" Text="Gestión Web de Tareas-Dedicación" CssClass="auto-style6"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style6" Text="Profesores"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10" style="background-color: #CCCC00">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Tareas</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" style="background-color: #CCCC00">
                        <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" style="background-color: #CCCC00">
                        <asp:HyperLink ID="HyperLink7" runat="server">Importar v. XMLDocument</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" style="background-color: #CCCC00">
                        <asp:HyperLink ID="HyperLink6" runat="server">Exportar</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" style="background-color: #CCCC00">
                        <asp:HyperLink ID="HyperLink5" runat="server">Importar v. DataSet</asp:HyperLink>
                    </td>
                </tr>
            </table>
        <div>
        </div>
    </form>
</body>
</html>
