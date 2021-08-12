<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsoClases.aspx.cs" Inherits="Proyecto1.UsoClases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
             <tr>
                <td>
                    ID Libro:
                    <asp:DropDownList ID="ddwLibros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddwLibros_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Libro:
                    <asp:TextBox ID="txtLibro" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/> 
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
                </td>
            </tr>
                <asp:GridView ID="gvDatos" runat="server">
                </asp:GridView>
            </table>
    </form>
</body>
</html>
