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
    <br />
    <strong>CONSULTA INDIVIDUAL DE PAQUETES</strong><br />
    <asp:Panel ID="Panel1" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" 
        Height="308px">
        <br />
        <p>
            Introduce el código del paquete que deseas consultar:
            <asp:TextBox ID="txtpedido" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Lrecibidousa" runat="server" BackColor="#99CCFF"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Lentransito" runat="server" BackColor="#CCFFCC"></asp:Label>
        </p>
        <p align="left">
            <asp:Label ID="Lenbodega" runat="server" BackColor="#FFFFCC"></asp:Label>
        </p>
        <p align="left">
            <asp:Label ID="Lentregado" runat="server" BackColor="#FFCCCC"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button7" runat="server" onclick="Button7_Click" 
                Text="Consultar paquete" />
        </p>
        <p>
            &nbsp;</p>
    </asp:Panel>
    <br />
    <strong>PRE-CARGA DE FACTURA</strong><br />
    <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" 
        Height="198px">
        <br />
        <p>
            Introduce el código del paquete del cual cargarás la factura:
            <asp:TextBox ID="txtcimg" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button8" runat="server" onclick="Button8_Click" 
                Text="Pre-cargar factura" />
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
    <br />
    <p>
        <asp:Button ID="Button4" runat="server" Text="Cotización" 
            onclick="Button4_Click" />
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="Editar perfil" 
            onclick="Button5_Click" />
    </p>
    <p align="right">
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
            Text="Cerrar Sesión" />
    </p>
    </form>
</body>
</html>
