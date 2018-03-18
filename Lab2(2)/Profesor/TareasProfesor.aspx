<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="Lab2_2_.Profesor.TareasProfesor" %>

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
<body style="height: 670px">
    <form id="form1" runat="server">
    
        <table style="width: 100%; height: 100px;">
            <tr>
                <td class="auto-style1" style="background-color: #808080">
                    <asp:Label ID="Label1" runat="server" style="font-size: x-large; font-weight: 700" Text="PROFESOR"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: x-large" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
                </td>
                <td class="auto-style2" style="background-color: #808080">
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
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" Height="19px" style="margin-left: 83px; margin-top: 12px" Width="174px" DataTextField="codigo" DataValueField="codigo">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS20ConnectionString %>" SelectCommand="SELECT a.codigo
FROM Asignaturas a
INNER JOIN GruposClase gc ON a.codigo=gc.codigoasig
WHERE EXISTS (SELECT gp.codigogrupo FROM ProfesoresGrupo gp WHERE gp.codigogrupo=gc.codigo AND gp.email=@email);">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="usuario" DefaultValue="" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS20ConnectionString %>" SelectCommand="SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas WHERE CodAsig=@codasig" UpdateCommand="UPDATE TareasGenericas
SET Descripcion=@descripcion, HEstimadas=@hestimadas, Explotacion=@explotacion, TipoTarea=@tipotarea
WHERE Codigo=@codigo;

">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="codasig" PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="descripcion" />
                <asp:Parameter Name="hestimadas" />
                <asp:Parameter Name="explotacion" />
                <asp:Parameter Name="tipotarea" />
                <asp:Parameter Name="codigo" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <p>
            <asp:Button ID="Button2" runat="server" Height="67px" style="text-align: center; margin-left: 81px; margin-top: 68px" Text="INSERTAR NUEVA TAREA" Width="212px" PostBackUrl="~/Profesor/InsertarTarea.aspx" />
        </p>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" BorderStyle="None" CssClass="auto-style2" DataSourceID="SqlDataSource1" style="margin-left: 66px; margin-top: 89px" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="Codigo">
            <AlternatingRowStyle BorderColor="#006666" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#006666" BorderColor="#006666" BorderStyle="None" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </form>
</body>
</html>
