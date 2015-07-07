<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modulodirector.aspx.cs" Inherits="modulodirector" %>

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
    <p>
        <strong>AUTORIZAR PRECARGA</strong><asp:Panel ID="Panel2" runat="server" 
         BackColor="#CCCCCC" BorderStyle="Dashed" 
        Height="551px" style="margin-bottom: 37px">
        <br />
        <p>
            Introduce el código del paquete del cual autorizarás:
            <asp:TextBox ID="txtcimg" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; El valor de la factura es:
            <asp:TextBox ID="txtprecio" runat="server" Enabled="False"></asp:TextBox>
        </p>
        <p align="right">
            <asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
                Text="Autorizar Precarga" />
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
                Text="Cargar precarga" />
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
    <asp:Panel ID="Panel3" runat="server" BackColor="#996633" BorderStyle="Dashed" 
        Height="155px">
        <p class="style1">
            <strong>Gestión de Empleados</strong></p>
        <p class="style1">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" 
            Text="Realizar Contratación" onclick="Button3_Click" />
        </p>
        <p align="center">
            <asp:Label ID="Label1" runat="server" BackColor="#FFFFCC"></asp:Label>
        </p>
        <p align="center">
            &nbsp;</p>
        <p align="center">
            &nbsp;</p>
    </asp:Panel>
    <p>
        &nbsp;Introduce el código del departamento a listar
        <asp:TextBox ID="txtcoddepto" runat="server"></asp:TextBox>
    </p>
    <asp:GridView ID="dgvempleados" runat="server" BackColor="#99CCFF" 
        BorderStyle="Dotted" EmptyDataText="No hay pedidos">
    </asp:GridView>
        <asp:Button ID="Button4" runat="server" Text="Consultar Equipo" 
        onclick="Button4_Click" />
    <p>
        <asp:Button ID="Button5" runat="server" Text="Modificar contratación" />
    </p>
    <p>
        <asp:Button ID="Button6" runat="server" 
            Text="Despedir Empleado" />
    </p>
    <p align="right">
        <asp:Button ID="Button13" runat="server" onclick="Button13_Click" 
            Text="Cerrar sesión" />
    </p>
    </form>
</body>
</html>
