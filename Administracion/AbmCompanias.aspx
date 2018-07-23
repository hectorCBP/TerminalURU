<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdministracion.Master" AutoEventWireup="true" CodeBehind="AbmCompanias.aspx.cs" Inherits="Administracion.AbmCompanias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td align="center" colspan="3" width="36%">
                <asp:Label ID="lblTitulo" runat="server" Text="Companias"></asp:Label>
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
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvBuscar" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvAgregarNombre" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="100%"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvAgregarDireccion" runat="server" 
                    ControlToValidate="txtDireccion" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtTelefono" runat="server" Width="100%" MaxLength="8"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvAgregarTelefono" runat="server" 
                    ControlToValidate="txtTelefono" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvTelefono" runat="server" 
                    ControlToValidate="txtTelefono" ErrorMessage="(número)" Font-Bold="False" 
                    ForeColor="Red" Operator="DataTypeCheck" Type="Integer" 
                    ValidationGroup="agregar"></asp:CompareValidator>
            </td>
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
