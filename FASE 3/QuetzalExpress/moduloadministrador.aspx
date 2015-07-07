<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moduloadministrador.aspx.cs" Inherits="moduloadministrador" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
    
        MODULO ADMINISTRADOR</div>
    <p>
        Bienvenido a su panel de control.</p>
    <p>
        &nbsp;<asp:Panel ID="Panel1" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" 
        Height="189px">
        <br />
        <p>
            A continuación puede importar datos en los siguientes campos:</p>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
                Text="Carga Masiva Bodega" />
            <asp:Button ID="Button7" runat="server" onclick="Button7_Click" 
                Text="Carga Masiva Empleados" />
            <asp:Button ID="Button8" runat="server" onclick="Button8_Click" 
                Text="Carga Masiva Impuestos" />
            <asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
                Text="Carga Masiva Paquetes" />
        </p>
        <p align="center">
            <asp:Label ID="Label1" runat="server" BackColor="#FFFFCC"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p align="left">
            &nbsp;</p>
        <p align="left">
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </asp:Panel>
    </p>
    <p class="style1">
        <strong>Gestión de Cobros</strong></p>
    <p>
        <asp:Button ID="Button3" runat="server" 
            Text="Agregar cobro" />
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Modificar Cobro" />
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="Inhabilitar Cobro" />
    </p>
    <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" 
        Height="295px">
        <p class="style1">
            <strong>Generar Reportes</strong></p>
        <p class="style1">
            <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
                Text="Resumen de paquetes por categoría" />
        </p>
        <p class="style1">
            <asp:Button ID="Button11" runat="server" onclick="Button11_Click" 
                Text="Resumen de paquetes por sucursal" />
        </p>
        <p class="style1">
            <asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
                Text="Resumen administrativo de empleados" />
        </p>
        <p class="style1">
            <asp:Button ID="Button13" runat="server" onclick="Button13_Click" 
                Text="Top 5 categorías más importadas" />
        </p>
        <br />
        <p align="center">
            <asp:Label ID="Label2" runat="server" BackColor="#FFFFCC"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p align="right">
            <asp:Button ID="Button14" runat="server" onclick="Button14_Click" 
                Text="Cerrar sesión" />
        </p>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" Visible="False" />
        <p align="left">
            &nbsp;</p>
        <p align="left">
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </asp:Panel>
    </form>
</body>
</html>
