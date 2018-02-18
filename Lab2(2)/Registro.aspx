<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Lab2_2_.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            width: 159px;
        }
        .auto-style3 {
            width: 178px;
        }
        .auto-style4 {
            width: 964px;
        }
        .auto-style5 {
            height: 407px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style5">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Registro"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" Target="_self">Inicio</asp:HyperLink>
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtboxEmail" ErrorMessage="*" ForeColor="Red" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtboxEmail" EnableClientScript="False" ErrorMessage="Email incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="txtboxNomYApe" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtboxNomYApe" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label6" runat="server" Text="Apellidos"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="txtboxApellidos" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtboxApellidos" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="txtboxPsw" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtboxPsw" ErrorMessage="*" ForeColor="Red" EnableClientScript="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label4" runat="server" Text="Repetir contraseña"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="txtboxRPsw" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtboxRPsw" ErrorMessage="*" ForeColor="Red" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtboxPsw" ControlToValidate="txtboxRPsw" EnableClientScript="False" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label5" runat="server" Text="Rol"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:DropDownList ID="ddRol" runat="server">
                <asp:ListItem Value="profesor">Profesor</asp:ListItem>
                <asp:ListItem Value="alumno">Alumno</asp:ListItem>
            </asp:DropDownList>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
            <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label ID="lblDev" runat="server" ForeColor="Blue" Text="lblDev"></asp:Label>
        </div>
    </form>
</body>
</html>
