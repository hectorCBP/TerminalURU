<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaDeViajes.aspx.cs" Inherits="Consultas.ConsultaDeViajes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de viajes</title>
    <link href="css/estilos.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="1000px">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlTerminal" runat="server" 
                        DataTextFormatString="Terminales" DataValueField="-1">
                        <asp:ListItem Selected="True" Value="-1">- Terminales -</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCompania" runat="server" 
                        DataTextFormatString="-- companias -- " DataValueField="-1">
                        <asp:ListItem Selected="True" Value="-1">- Companias -</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblDesde" runat="server" CssClass="label" Text="Desde"></asp:Label>
                    <asp:TextBox ID="txtDesde" runat="server" Width="100px"></asp:TextBox>
                    <asp:ImageButton ID="btnDesde" runat="server" 
                        ImageUrl="~/imagenes/calendario.png" Width="28px" 
                        CssClass="btnCalendario" onclick="btnDesde_Click" />
                </td>
                <td>
                    <asp:Label ID="lblHasta" runat="server" CssClass="label" Text="Hasta"></asp:Label>
                    <asp:TextBox ID="txtHasta" runat="server" Width="100px"></asp:TextBox>
                    <asp:ImageButton ID="btnHasta" runat="server" 
                        ImageUrl="~/imagenes/calendario.png" Width="28px" 
                        CssClass="btnCalendario" onclick="btnHasta_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="btnImgBuscar" runat="server" 
                        ImageUrl="~/imagenes/lupa.png" Width="28px" onclick="btnImgBuscar_Click" 
                        BorderColor="#FF6600" BorderStyle="Solid" />
                </td>
                <td>
                    <asp:ImageButton ID="btnImgLimpiar" runat="server" 
                        ImageUrl="~/imagenes/limpiar.png" Width="28px" BorderColor="#FF3300" 
                        BorderStyle="Solid" onclick="btnImgLimpiar_Click"/>
                </td>
            </tr>
            <tr>
                <td align="center"></td>
                <td align="center"></td>
                <td align="center">
                    <asp:Calendar ID="calendarDesde" runat="server" Visible="False" 
                        BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                        Width="200px" onselectionchanged="calendarDesde_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td align="center">
                    <asp:Calendar ID="calendarHasta" runat="server" Visible="False" 
                        BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                        Width="200px" onselectionchanged="calendarHasta_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td align="center"></td>
                <td align="center"></td>
            </tr>
            <tr>
                <td align="center" colspan="5">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div>
    <table>
        <tr>
            <th>Número</th>
            <th>Companía</th>
            <th>País</th>
            <th>Ciudad</th>
            <th>Salida</th>
            <th>Llegada</th>
            <th></th>
        </tr>            
        <asp:Repeater ID="repeaterViajes" runat="server" 
            onitemcommand="repeaterViajes_ItemCommand">
            <ItemTemplate>                
                    <tr  class="repiter">
                        <td>
                            <asp:TextBox ID="numeroViaje" runat="server" Text='<%# Bind("NumeroViaje") %>' Enabled=false> </asp:TextBox>  
                        </td>
                        <td>
                            <asp:TextBox ID="nombreCompania" runat="server" Text='<%# Bind("Compania.Nombre") %>' Enabled=false> </asp:TextBox>  
                        </td>
                        <td>
                            <asp:TextBox ID="terminalPais" runat="server" Text='<%# Bind("Terminal.Pais") %>' Enabled=false> </asp:TextBox>  
                        </td>
                        <td>
                            <asp:TextBox ID="trerminalCiudad" runat="server" Text='<%# Bind("Terminal.Ciudad") %>' Enabled=false> </asp:TextBox>  
                        </td>
                        <td>
                            <asp:TextBox ID="fechaSalida" runat="server" Text='<%# Bind("FHSalida") %>' Enabled=false> </asp:TextBox>  
                        </td>
                        <td>
                            <asp:TextBox ID="fechaLlegada" runat="server" Text='<%# Bind("FHLlegada") %>' Enabled=false> </asp:TextBox>  
                        </td>
                        <td>
                            <asp:Button ID="btnMasInfo" runat="server" CommandName="Info" Text="ver más" />
                        </td>
                    </tr>                
            </ItemTemplate>
        </asp:Repeater>            
        </table>
    </div>
    </form>
</body>
</html>
