<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdministracion.Master" AutoEventWireup="true" CodeBehind="AbmNacionales.aspx.cs" Inherits="Administracion.AbmNacionales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td align="center" colspan="3" width="36%">
                <asp:Label ID="lblTitulo" runat="server" Text="Viajes Nacionales"></asp:Label>
            </td>
            <td align="center" colspan="2" width="20%">
                <asp:ImageButton ID="imgBtnBuscar" runat="server" BorderColor="#FF6600" 
                    BorderStyle="Solid" ImageUrl="~/imagenes/lupa.png" Width="25px" />
&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgBtnLimpiar" runat="server" BorderColor="#FF6600" 
                    BorderStyle="Solid" ImageUrl="~/imagenes/limpiar.png" Width="25px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNumViaje" runat="server" Text="Numero de viaje:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtNumViaje" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td align="center" colspan="2" width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFSalida" runat="server" Text="Fecha de salida:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtFSalida" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td align="center" colspan="2" width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFLlegada" runat="server" Text="Fecha de llegada:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtFLlegada" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td align="center" colspan="2" width="20%">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblAsientos" runat="server" Text="Asientos:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtAsientos" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td align="center" colspan="2" width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTerminal" runat="server" Text="Terminal:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:DropDownList ID="ddlTerminales" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td align="center" colspan="2" width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCompania" runat="server" Text="Companía:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:DropDownList ID="ddlCompanias" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td align="center" colspan="2" width="20%">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblParadas" runat="server" Text="Paradas intermedias:"></asp:Label>
            </td>
            <td align="left" colspan="3" width="36%">
                <asp:TextBox ID="txtPIntermedias" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td align="center" colspan="2" width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7" style="width: 56%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7" style="width: 56%" align="center">
                <asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="width: 56%">
                <hr />
            </td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td align="center" colspan="2" width="20%">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
            </td>
            <td align="center" width="20%">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
            </td>
            <td align="center" colspan="2" width="20%">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
            </td>
            <td width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
