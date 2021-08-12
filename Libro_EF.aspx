<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Libro_EF.aspx.cs" Inherits="Proyecto1.Libro_EF" %>

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
                    ID Libro:
                    <asp:DropDownList ID="ddwLibros" runat="server" AutoPostBack="True" ></asp:DropDownList>
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
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /> 
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <!--
                        Fecha: 29/06/2021
                        Autor Daniel Hernandez Cruz
                        -->
                    <asp:Button ID="btnReporte" runat="server" Text="Reporte" OnClick="btnReporte_Click" />
                </td>
            </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvDatos" runat="server" PageSize="3">

                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
