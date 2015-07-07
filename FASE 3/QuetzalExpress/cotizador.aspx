<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cotizador.aspx.cs" Inherits="cotizador" %>

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
    <div class="style1">
    
        <strong style="text-align: center">COTIZADOR DE PRECIO</strong></div>
    <p>
        &nbsp;</p>
    <p>
        Precio en USA USD$:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        Peso en LBS:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>
        Impuesto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl1" runat="server" Height="16px" Width="121px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Cotizar" runat="server" onclick="Button1_Click" 
            Text="Cotizar" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="Atras" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    </form>
</body>
</html>
