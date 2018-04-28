<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerHorasMedias.aspx.cs" Inherits="Lab2_2_.Profesor.VerHorasMedias" %>

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
        .auto-style2 {
            height: 98px;
        }
        .auto-style3 {
            height: 23px;
            width: 255px;
            margin-left: 0px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
        <table style="width: 100%; height: 100px;">
            <tr>
                <td class="auto-style1" style="background-color: #99CC00">
                    <asp:Label ID="Label1" runat="server" style="font-size: x-large; font-weight: 700" Text="COORDINADOR"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: x-large" Text="HORAS MEDIAS POR ASIGNATURA"></asp:Label>
                </td>
                <td class="auto-style2" style="background-color: #99CC00">
                    <div class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LogOut.aspx">Cerrar sesión</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>
        <div>
        <div style="height: 53px">
        </div>
    
        </div>
        <div style="margin-left: 80px">
            <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Seleccionar Asignatura:"></asp:Label>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" Height="19px" style="margin-left: 83px; margin-top: 12px" Width="174px" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS20ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Horas medias estimadas por los alumnos: "></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
