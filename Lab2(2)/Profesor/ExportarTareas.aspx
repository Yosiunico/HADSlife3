<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarTareas.aspx.cs" Inherits="Lab2_2_.Profesor.ExportarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 749px;
        }
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            width: 350px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 93px; text-align: center; background-color: #808080">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="PROFESOR"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="auto-style1" Text="EXPORTAR TAREAS GENÉRICAS"></asp:Label>
        </div>
    <div style="height: 401px; width: 1335px;">
    
            <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS20ConnectionString %>" SelectCommand="SELECT a.codigo
FROM Asignaturas a
INNER JOIN GruposClase gc ON a.codigo=gc.codigoasig
WHERE EXISTS (SELECT gp.codigogrupo FROM ProfesoresGrupo gp WHERE gp.codigogrupo=gc.codigo AND gp.email=@email);">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="usuario" DefaultValue="" />
            </SelectParameters>
        </asp:SqlDataSource>
    
            <table style="width:100%;">
                <tr>
                    <td>
    
            <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Seleccionar Asignatura a Importar:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" Height="19px" style="margin-left: 2px; margin-top: 12px" Width="174px" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnDataBound="DropDownList2_DataBound">
        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td rowspan="2">
                        <asp:GridView ID="GridView1" runat="server" style="float: left; margin-left: 0px; margin-right: 0px">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Height="62px" OnClick="Button1_Click" Text="EXPORTAR" Width="134px" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
