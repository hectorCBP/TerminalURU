<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdministracion.Master" AutoEventWireup="true" CodeBehind="AbmEmpleados.aspx.cs" Inherits="Administracion.AbmEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td align="center" colspan="3" width="36%">
                <asp:Label ID="lblTitulo" runat="server" Text="Empleados"></asp:Label>
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
                <asp:Label ID="lblCedula" runat="server" Text="Cédula"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtCedula" runat="server" MaxLength="8" Width="100%"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvBuscarCedula" runat="server" 
                    ControlToValidate="txtCedula" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvCedula" runat="server" 
                    ControlToValidate="txtCedula" ErrorMessage="(número)" Font-Bold="False" 
                    ForeColor="Red" Operator="DataTypeCheck" Type="Integer" 
                    ValidationGroup="buscar"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" Width="100%"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvAgregarNombre" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblClave" runat="server" Text="Clave:"></asp:Label>
            </td>
            <td align="center" colspan="3" width="36%">
                <asp:TextBox ID="txtClave" runat="server" Width="100%" MaxLength="6"></asp:TextBox>
            </td>
            <td align="left" colspan="2" width="20%">
                <asp:RequiredFieldValidator ID="rfvAgregarClave" runat="server" 
                    ControlToValidate="txtClave" ErrorMessage="(*)" Font-Bold="True" 
                    ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="width: 56%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7" style="width: 56%" align="center">
                &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>
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
