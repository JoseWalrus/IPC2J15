<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moduloempleado.aspx.cs" Inherits="moduloempleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
    <div align="center">
    
        MODULO EMPLEADO</div>
    <p>
        Bienvenido a su panel de control.</p>
     <p class="style1">
         <strong>Gestión de Paquetes</strong></p>
    <p>
        <asp:Button ID="Button3" runat="server" 
            Text="Registrar Paquete" />
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Añadir Paquete a Lote" />
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="Control de estado" />
    </p>
     <p class="style1">
         <strong>Gestión de Bodegas</strong></p>
     <p>
        <asp:Button ID="Button6" runat="server" 
            Text="Reportar Paquete Perdido" />
    </p>
     <p class="style1">
         <strong>Gestión de Servicio al Cliente</strong></p>
     <p class="style1">
        <asp:Button ID="Button7" runat="server" 
            Text="Entrega y Facturación" onclick="Button7_Click" />
    </p>
     <p class="style1">
        <asp:Button ID="Button8" runat="server" 
            Text="Devolución" />
    </p>
     <p class="style1">
        <asp:Button ID="Button9" runat="server" 
            Text="Búsqueda Cliente" />
    </p>
    </form>
</body>
</html>
