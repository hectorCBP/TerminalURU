<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdministracion.Master" AutoEventWireup="true" CodeBehind="AbmTerminales.aspx.cs" Inherits="Administracion.AbmTerminales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td align="center" colspan="3" width="36%">
                <asp:Label ID="lblTitulo" runat="server" Text="Terminales"></asp:Label>
            </td>
            <td align="center" colspan="2" width="20%">
                <asp:ImageButton ID="imgBtnBuscar" runat="server" BorderColor="#FF6600" 
                    BorderStyle="Solid" ImageUrl="~/imagenes/lupa.png" Width="25px" 
                    onclick="imgBtnBuscar_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgBtnLimpiar" runat="server" BorderColor="#FF6600" 
                    BorderStyle="Solid" ImageUrl="~/imagenes/limpiar.png" Width="25px" 
                    onclick="imgBtnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCodigo" runat="server" Text="Codigo:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtCodigo" runat="server" MaxLength="3" Width="100%"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvBuscarCodigo" runat="server" 
                    ControlToValidate="txtCodigo" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvAgregarCodigo" runat="server" 
                    ControlToValidate="txtCodigo" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtCiudad" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvAgregarCiudad" runat="server" 
                    ControlToValidate="txtCiudad" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblPais" runat="server" Text="País:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtPais" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvAgregarPais" runat="server" 
                    ControlToValidate="txtPais" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFacilidades" runat="server" Text="Facilidades:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:GridView ID="gvFacilidades" runat="server">
                </asp:GridView>
            </td>
            <td align="left" colspan="2" width="20%">
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
                <asp:Button ID="btnEliminar" runat="server" Enabled="False" 
                    onclick="btnEliminar_Click" Text="Eliminar" />
            </td>
            <td align="center" width="20%">
                <asp:Button ID="btnModificar" runat="server" Enabled="False" 
                    onclick="btnModificar_Click" Text="Modificar" ValidationGroup="agregar" />
            </td>
            <td align="center" colspan="2" width="20%">
                <asp:Button ID="btnAgregar" runat="server" Enabled="False" 
                    onclick="btnAgregar_Click" Text="Agregar" ValidationGroup="agregar" />
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
