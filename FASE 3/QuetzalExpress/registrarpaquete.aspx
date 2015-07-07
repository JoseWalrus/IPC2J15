<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrarpaquete.aspx.cs" Inherits="registrarpaquete" %>

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
<body style="height: 459px">
    <form id="form1" runat="server">
    <div>
    
    <div class="style1">
    
        <strong>REGISTRO DE PAQUETES</strong></div>
    <p>
        Casilla de Cliente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtcasilla" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Precio USA:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtpreciousa" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
       Impuesto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl1" runat="server" Height="16px" Width="130px">
        </asp:DropDownList>
    </p>
    <p>
        Comisión:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; ;
        <asp:DropDownList ID="ddl2" runat="server" Height="16px" Width="130px">
        </asp:DropDownList>
    </p>
    <p>
      Descuento:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl3" runat="server" Height="16px" Width="130px">
        </asp:DropDownList>
    </p>
    <p>
        Peso Libras:&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtpeso" runat="server"></asp:TextBox>
    </p>
    <p>
        Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
            ID="txttotal" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
            ID="Button1" runat="server" onclick="Button3_Click" 
            Text="Registrar y añadir a lote actual" />
        <asp:Button ID="Button4" runat="server" onclick="Button1_Click" 
            Text="Calcular Total" />
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
            Text="Añadir masivamente CSV" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Atras" />
    </p>
        <p>
        Actualmente el Lote que se encuentra en sesión es el Número:
            <asp:Label ID="Lloteactual" runat="server" BackColor="#CCFFCC"></asp:Label>
    </p>
        <p>
            Si el paquete es añadido sin precio en USA, el cliente deverá cargar la factura 
            para su aprovación.</p>
        <p align="center">
            <asp:Label ID="Linforme" runat="server" BackColor="#FFCCCC"></asp:Label>
    </p>
    
    </div>
    </form>
</body>
</html>
