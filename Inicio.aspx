<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Proyecto1.Inicio" %>

<!DOCTYPE html>
<!--Programacion del lado  del cliente Frontend-->

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
                    <asp:DropDownList ID="ddwLibros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddwLibros_SelectedIndexChanged" ></asp:DropDownList>
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
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvDatos" runat="server" OnRowDataBound="gvDatos_RowDataBound" >
                    </asp:GridView>
                </td>        
            </tr>
        </table>
    </form>
</body>

</html>
