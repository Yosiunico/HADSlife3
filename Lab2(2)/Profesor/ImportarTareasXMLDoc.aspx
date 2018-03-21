<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTareasXMLDoc.aspx.cs" Inherits="Lab2_2_.Profesor.ImportarTareasXMLDoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


        .auto-style1 {
            width: 789px;
            height: 98px;
            text-align: center;
        }
        #form1 {
            height: 506px;
        }
    </style>
</head>
<body style="height: 486px">
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%; height: 100px;">
            <tr>
                <td class="auto-style1" style="background-color: #808080">
                    <br />
                    <div style="width: 1006px; height: 64px; margin-top: 0px; margin-bottom: 43px">
                    <asp:Label ID="Label1" runat="server" style="font-size: x-large; font-weight: 700" Text="PROFESOR"></asp:Label>
                        <br />
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: x-large" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <div>
        <div style="height: 53px">
        </div>
    
        </div>
    
    </div>
        <div style="margin-left: 80px">
            <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Seleccionar Asignatura a Importar:"></asp:Label>
            <br />
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" Height="19px" style="margin-left: 2px; margin-top: 12px" Width="174px" DataTextField="codigo" DataValueField="codigo">
        </asp:DropDownList>
        </div>
            <asp:Button ID="Button1" runat="server" Height="67px" style="text-align: center; margin-left: 81px; margin-top: 68px" Text="IMPORTAR (XMLD)" Width="212px" PostBackUrl="~/Profesor/InsertarTarea.aspx" />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/Profesor.aspx">Menu Profesor</asp:HyperLink>
    </form>
</body>
</html>
