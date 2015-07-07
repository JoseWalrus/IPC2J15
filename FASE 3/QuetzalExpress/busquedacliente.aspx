<%@ Page Language="C#" AutoEventWireup="true" CodeFile="busquedacliente.aspx.cs" Inherits="busquedacliente" %>

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
    
        <strong>BUSQUEDA DE CLIENTE</strong></div>
    <p>
        Introduce el nombre del cliente y su DPI para obtener la casilla</p>
    <p>
        DPI:
        <asp:TextBox ID="txtdpi" runat="server" Width="213px"></asp:TextBox>
    </p>
    <p>
        Nombre:<asp:TextBox ID="txtnombre" runat="server" Width="213px"></asp:TextBox>
    </p>
    <p>
        Apellido:<asp:TextBox ID="txtapellido" runat="server" Width="213px"></asp:TextBox>
    </p>
    <p>
        La casilla del cliente es:
        <asp:Label ID="Lcasillacliente" runat="server" BackColor="#66CCFF" 
            ForeColor="Black"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Buscar" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Atras" />
    </p>
    </form>
</body>
</html>
