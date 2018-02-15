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
            <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" style="margin-left: 180px; margin-top: 0px; margin-bottom: 0px" Width="117px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" EnableClientScript="False" ErrorMessage="Correo incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Código de confirmación"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 67px" TextMode="Number" Width="116px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Confirmar" />
        </p>
    </form>
</body>
</html>
