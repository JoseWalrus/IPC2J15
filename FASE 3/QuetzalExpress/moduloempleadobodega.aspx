<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moduloempleadobodega.aspx.cs" Inherits="moduloempleadobodega" %>

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
     <form id="form4" runat="server">
    <div align="center" class="style1">
    
        <strong>MODULO EMPLEADO DE BODEGA</strong></div>
    <p>
        Bienvenido a su panel de control.</p>
     <p class="style1">
         <strong>Gestión de Bodegas</strong></p>
     <p>
        <asp:Button ID="Button6" runat="server" 
            Text="Reportar Paquete Perdido" />
    </p>
     <p>
         <strong>REVISIÓN PRE-CARGA</strong><asp:Panel ID="Panel2" runat="server" 
         BackColor="#CCCCCC" BorderStyle="Dashed" 
        Height="551px" style="margin-bottom: 37px">
        <br />
        <p>
            Introduce el código del paquete del cual revisarás la factura:
            <asp:TextBox ID="txtcimg" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Introduce el valor de la factura:
            <asp:TextBox ID="txtprecio" runat="server"></asp:TextBox>
        </p>
         <p align="right">
             <asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
                 Text="Actualizar valor de factura" />
         </p>
        <p align="center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
    <Columns>
        <asp:BoundField DataField="Text" />
        <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="500" ControlStyle-Width="500" />
    </Columns>
</asp:GridView>
        </p>
        <p>
            <asp:Button ID="Button8" runat="server" onclick="Button8_Click" 
                Text="Cargar Factura" />
        </p>
        <p align="center">
            <asp:Label ID="Lcarga" runat="server" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label>
        </p>
        <p align="center">
            &nbsp;</p>
        <p align="center">
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </asp:Panel>
    </p>
     <p class="style1" align="right">
         <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
             Text="Cerrar Sesión" />
    </p>
    </form>
    </body>
</html>
