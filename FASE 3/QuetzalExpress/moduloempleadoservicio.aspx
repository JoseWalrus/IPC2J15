<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moduloempleadoservicio.aspx.cs" Inherits="moduloempleadoservicio" %>

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
     <form id="form3" runat="server">
    <div align="center" class="style1">
    
        <strong>MODULO EMPLEADO DE SERVICIO AL CLIENTE</strong></div>
    <p>
        Bienvenido a su panel de control.</p>
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
            Text="Búsqueda Cliente" onclick="Button9_Click" />
    </p>
     <p class="style1" align="right">
         <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
             Text="Cerrar Sesión" />
    </p>
    </form>
    
</body>
</html>
