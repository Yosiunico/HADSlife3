<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmar.aspx.cs" Inherits="Lab2_2_.Confirmar" %>

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
            height: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Confirmación"></asp:Label>
            <br />
            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text="¡Error!" Visible="False"></asp:Label>
            <br />
            <div id="Div1" runat="server" class="auto-style2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Ir a la pagina de Login</asp:HyperLink>
            </div>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
