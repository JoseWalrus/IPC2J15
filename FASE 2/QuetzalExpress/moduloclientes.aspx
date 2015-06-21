<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moduloclientes.aspx.cs" Inherits="moduloclientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
        MODULO CLIENTES</div>
    <p>
        Bienvenido a su panel de control.</p>
    <p>
        <asp:Button ID="Button3" runat="server" 
            Text="Consulta de información de paquetes" onclick="Button3_Click" />
    </p>
    <asp:GridView ID="dgvpedidos" runat="server" BackColor="#99CCFF" 
        BorderStyle="Dotted" EmptyDataText="No hay pedidos">
    </asp:GridView>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Cotización" 
            onclick="Button4_Click" />
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="Editar perfil" 
            onclick="Button5_Click" />
    </p>
    </form>
</body>
</html>
