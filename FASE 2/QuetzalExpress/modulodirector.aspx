﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modulodirector.aspx.cs" Inherits="modulodirector" %>

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
    
        MODULO DIRECTOR</div>
    <p>
        Bienvenido a su panel de control.</p>
    <p class="style1">
        <strong>Gestión de Empleados</strong></p>
    <p>
        <asp:Button ID="Button3" runat="server" 
            Text="Realizar Contratación" onclick="Button3_Click" />
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Consultar Equipo" />
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="Modificar contratación" />
    </p>
    <p>
        <asp:Button ID="Button6" runat="server" 
            Text="Despedir Empleado" />
    </p>
    </form>
</body>
</html>
