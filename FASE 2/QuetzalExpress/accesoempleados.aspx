<%@ Page Language="C#" AutoEventWireup="true" CodeFile="accesoempleados.aspx.cs" Inherits="accesoempleados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" 
        style="display: block; float: inherit; clear: none; cursor: auto">
    
        <br />
    
        <asp:Image ID="Image1" runat="server" Height="696px" ImageAlign="Middle" 
            ImageUrl="~/Imagen/Imagen1.jpg" style="text-align: center" Width="586px" />
    
        <br />
        <br />
        Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    Contraseña:<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Bienvenido a Quetzal Express debes acceder para 
            ayudarnos a crecer.<br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="Ingresar" />
            <br />
    
    </div>
    </form>
</body>
</html>
