<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Lab2_2_.Profesor.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
        .auto-style2 {
            height: 98px;
            text-align: center;
        }
        .auto-style3 {
            width: 100%;
            height: 128px;
        }
        .auto-style4 {
            height: 100px;
        }
        .auto-style5 {
            margin-left: 0px;
        }
        .auto-style6 {
            width: 892px;
            margin-left: 763px;
        }
        .auto-style8 {
            width: 204px;
            height: 69px;
            margin-left: 94px;
            resize: none;
        }
        .auto-style9 {
            height: 26px;
            width: 147px;
            text-align: left;
        }
        .auto-style10 {
            height: 68px;
            text-align: left;
        }
        .auto-style12 {
            height: 64px;
            width: 147px;
            text-align: left;
        }
        .auto-style13 {
            width: 204px;
            height: 64px;
            margin-left: 94px;
            resize: none;
        }
        .auto-style14 {
            width: 892px;
            margin-left: 763px;
            height: 64px;
        }
        .auto-style15 {
            height: 119px;
            width: 147px;
            text-align: left;
        }
        .auto-style16 {
            width: 892px;
            margin-left: 763px;
            height: 119px;
        }
        .auto-style17 {
            width: 204px;
            height: 119px;
            margin-left: 94px;
            resize: none;
        }
        .auto-style18 {
            margin-left: 0px;
            margin-top: 0px;
            resize: none;
        }
        .auto-style19 {
            width: 892px;
            margin-left: 553px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        </style>
</head>
<body style="height: 532px">
    <form id="form1" runat="server">
        <div class="auto-style1">
    
        <table class="auto-style3">
            <tr>
                <td class="auto-style2" style="background-color: #808080">
                    <asp:Label ID="Label1" runat="server" style="font-size: x-large; font-weight: 700" Text="PROFESOR"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: x-large" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
                </td>
            </tr>
        </table>
        </div>
        <div class="auto-style4">
        </div>
        <strong>
        <div class="auto-style5">
            <table class="auto-style4">
                <tr>
                    <td class="auto-style9">
        <strong>
            <asp:Label ID="Label9" runat="server" Text="Código"></asp:Label>
        </strong>
                    </td>
                    <td class="auto-style8">
        <strong>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5" Width="152px"></asp:TextBox>
        </strong>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
        <strong>
            <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                        <br />
                        <br />
                        <br />
        </strong>
                    </td>
                    <td class="auto-style17">
        <strong>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style18" Width="195px" Height="70px" TextMode="MultiLine"></asp:TextBox>
        </strong>
                    </td>
                    <td class="auto-style16">
        <strong>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <br />
        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label5" runat="server" Text="Asignatura"></asp:Label>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style13">
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" Height="16px" Width="163px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS20ConnectionString %>" SelectCommand="SELECT a.codigo
FROM Asignaturas a
INNER JOIN GruposClase gc ON a.codigo=gc.codigoasig
WHERE EXISTS (SELECT gp.codigogrupo FROM ProfesoresGrupo gp WHERE gp.codigogrupo=gc.codigo AND gp.email=@email);">
                            <SelectParameters>
                                <asp:SessionParameter Name="email" SessionField="usuario" DefaultValue="" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label6" runat="server" Text="Horas Estimadas"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="TextBox2" runat="server" Width="50px" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
        <strong>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style9">
        <strong>
                        <asp:Label ID="Label11" runat="server" Text="Tipo tarea"></asp:Label>
                        <br />
                        <br />
        </strong>
                    </td>
                    <td class="auto-style8">
        <strong>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="tt" DataValueField="tt" Height="16px" Width="163px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS20ConnectionString %>" SelectCommand="SELECT DISTINCT TipoTarea tt
FROM TareasGenericas"></asp:SqlDataSource>
        </strong>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" colspan="2">
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Añadir tarea" Height="53px" style="text-align: center; margin-left: 91px; margin-right: 0px" Width="130px" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style10"></td>
                </tr>
            </table>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
        <strong>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <div class="auto-style19">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Ver Tareas</asp:HyperLink>
            </div>
            </strong>
            <br />
        <strong>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </strong><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <strong>
            <br />
            <br />
            <br />
            <br />
            </strong>
            </div>
        </strong>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
