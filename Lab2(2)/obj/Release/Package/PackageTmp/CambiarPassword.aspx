<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Lab2_2_.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Cambiar Password</title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            height: 97px;
        }
        .auto-style3 {
            height: 105px;
        }
        .auto-style4 {
            margin-left: 0px;
        }
        .auto-style5 {
            width: 201px;
        }
        .auto-style6 {
            height: 399px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
            width: 112px;
        }
        .auto-style9 {
            width: 112px;
        }
        .auto-style10 {
            width: 100%;
            height: 57px;
            margin-bottom: 5px;
        }
        .auto-style11 {
            width: 201px;
            height: 35px;
        }
        .auto-style12 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style6">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Cambiar Contraseña"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" Target="_self">Inicio</asp:HyperLink>
            <br />
            <br />
            <div id="DIVMandarMail" runat="server" class="auto-style2">
&nbsp;&nbsp;&nbsp;<table class="auto-style10">
                    <tr>
                        <td class="auto-style8">
            <asp:Label ID="Label3" runat="server" Text="Email "></asp:Label>
                        </td>
                        <td class="auto-style7">
            <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtboxEmail" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtboxEmail" EnableClientScript="False" ErrorMessage="Email incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style7"></td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td>
            <asp:Button ID="btnMandarMail" runat="server" Text="Cambiar contraseña" OnClick="btnMandarMail_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
            <br />
            <div id="DIVCambiarPasw" runat="server" class="auto-style3">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style5">
            <asp:Label ID="Label5" runat="server" Text="Nueva contraseña"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txtboxPsw" runat="server" TextMode="Password" CssClass="auto-style4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtboxPsw" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
            <asp:Label ID="Label6" runat="server" Text="Repetir nueva contraseña"></asp:Label>
                    </td>
                    <td class="auto-style12"><asp:TextBox ID="txtboxRPsw" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtboxRPsw" EnableClientScript="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtboxPsw" ControlToValidate="txtboxRPsw" EnableClientScript="False" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                    </td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
            <asp:Button ID="btnCambiarPsw" runat="server" Text="Cambiar contraseña" OnClick="btnCambiarPsw_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
                </div>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
