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
    <div align="center" class="style1">
    
        <strong>MODULO EMPLEADO DE REGISTRO</strong></div>
    <p>
        Bienvenido a su panel de control.</p>
     <p class="style1">
         <strong>Gestión de Paquetes</strong></p>
    <p>
        <asp:Button ID="Button3" runat="server" 
            Text="Registrar Paquete" onclick="Button3_Click" />
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Enviar Lote Actual" 
            onclick="Button4_Click" />
    </p>
    <p>
        Actualmente el Lote que se encuentra en sesión es el Número:
        <asp:Label ID="Lcod_actual" runat="server" BackColor="#CCFFCC"></asp:Label>
     </p>
     <p class="style1" align="right">
         <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
             Text="Cerrar Sesión" />
    </p>
    </form>
</body>
</html>
