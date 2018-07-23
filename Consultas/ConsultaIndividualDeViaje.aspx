<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaIndividualDeViaje.aspx.cs" Inherits="Consultas.ConsultaIndividualDeViaje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="margin: 0 auto; width: 600px;">
            <tr>
                <td align="center" colspan="2" style="bottom: 2px">
                    <asp:LinkButton ID="lnkBtnVolver" runat="server" 
                        PostBackUrl="~/ConsultaDeViajes.aspx">Volver</asp:LinkButton>
                    &nbsp;
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    Datos de Viaje</td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblNumViaje" runat="server" Text="Número de viaje:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblNumViajeVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha de salida:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblFechaSalidaVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblFechaLlegada" runat="server" Text="Fecha de llegada:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblFechaLlegadaVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblAsientos" runat="server" Text="Asientos:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblAsientosVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblParadas" runat="server" Text="Paradas intermedias:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblParadasVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblServicio" runat="server" Text="Servicio a bordo:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblServicioVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" style="bottom: 2px" width="50%">
                    <asp:Label ID="lblDocumentacion" runat="server" Text="Documentacion:"></asp:Label>
                </td>
                <td class="style1" style="bottom: 2px" width="50%">
                    </td>
            </tr>
            <tr>
                <td colspan="2" class="style1" style="bottom: 2px">
                    <textarea id="txtAreaDocumentacion" cols="20" name="S1" rows="2" runat="server"
                        style="width: 50%"></textarea></td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    Datos de Companía</td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblNomCompania" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblNomCompaniaVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblDireccionVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblTelefonoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    Datos de Terminal</td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblCodigo" runat="server" Text="Codigo de terminal:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblCodigoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblPais" runat="server" Text="Pais:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblPaisVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
                </td>
                <td style="bottom: 2px" width="50%">
                    <asp:Label ID="lblCiudadVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="bottom: 2px">
                    <asp:GridView ID="GVFacilidades" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="50%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="FacilidadProp" HeaderText="Facilidades:" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
