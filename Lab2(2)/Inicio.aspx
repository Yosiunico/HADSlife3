<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Lab2_2_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 810px;
            height: 297px;
        }
        .auto-style2 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Inicio"></asp:Label>
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registro.aspx" Target="_self">Registrarse</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CambiarPassword.aspx" Target="_self">Cambiar contraseña</asp:HyperLink>
        </div>
    </form>
</body>
</html>
