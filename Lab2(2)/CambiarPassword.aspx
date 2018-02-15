<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Lab2_2_.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Cambiar Contraseña"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" Target="_self">Inicio</asp:HyperLink>
            <br />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtboxEmail" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtboxEmail" EnableClientScript="False" ErrorMessage="Email incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnMandarMail" runat="server" Text="Cambiar contraseña" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Código"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxCodigo" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtboxCodigo" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Nueva contraseña"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxPsw" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtboxPsw" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Repetir nueva contraseña"></asp:Label>
&nbsp;<asp:TextBox ID="txtboxRPsw" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtboxRPsw" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtboxPsw" ControlToValidate="txtboxRPsw" EnableClientScript="False" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            <asp:Button ID="btnCambiarPsw" runat="server" Text="Cambiar contraseña" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
