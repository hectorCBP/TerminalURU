<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Administracion.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" 
            style="border: thin solid #FF6600; width: 400px; margin: 100px auto 0 auto; text-align: center;">

            <br />
            <asp:Label ID="lblIniSesion" runat="server" Text="Inicio De Sesión"></asp:Label>
            <br />
            <br />
            <br /><asp:TextBox ID="txtCiEmpleado" runat="server" Width="60%" placeholder="CI Empleado"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtClave" runat="server" Width="60%" placeholder="Clave" 
                TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="60%" 
                onclick="btnAceptar_Click" />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
