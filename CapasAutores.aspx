<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapasAutores.aspx.cs" Inherits="Proyecto1.CapasAutores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
             <tr>
                <td>
                    ID Autor:
                    <asp:DropDownList ID="ddwAutores" runat="server" AutoPostBack="True"   ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Autor:
                    <asp:TextBox ID="txtAutor" runat="server" Text=""></asp:TextBox>
                    Telefono:
                    <asp:TextBox ID="txtTelefono" runat="server" Text=""></asp:TextBox>
                    Fecha de Nacimiento:
                    <asp:TextBox ID="txtFecN" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"  /> 
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                </td>
            </tr>
                <asp:GridView ID="gvDatos" runat="server">
                </asp:GridView>
            </table>
        </div>
    </form>
</body>
</html>
