<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Lab2_2_.Alumno.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            background-color: #C0C0C0;
        }
        .auto-style2 {
            font-size: xx-large;
            background-color: #C0C0C0;
        }
        .auto-style3 {
            background-color: #C0C0C0;
        }
        .auto-style4 {
            width: 100%;
            height: 130px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
            width: 727px;
        }
        .auto-style9 {
            height: 26px;
            width: 147px;
            text-align: left;
        }
        .auto-style10 {
            height: 68px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="ALUMNOS"></asp:Label>
                <br class="auto-style3" />
                <br class="auto-style2" />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style2" Text="INSTANCIAR TAREA GENÉRICA"></asp:Label>
            </div>
            <br />
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label3" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtBoxUsuario" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label4" runat="server" Text="Tarea"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtBoxTarea" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label5" runat="server" Text="Horas Est."></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtBoxEst" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label6" runat="server" Text="Horas Reales"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtBoxReales" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" colspan="2">
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Crear tarea" Height="53px" style="text-align: center; margin-left: 91px; margin-right: 0px" Width="130px" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style10"></td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="GVTareas" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="log" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
