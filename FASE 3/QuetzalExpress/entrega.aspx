<%@ Page Language="C#" AutoEventWireup="true" CodeFile="entrega.aspx.cs" Inherits="entrega" %>

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
    <div align="center" class="style1">
    
        <strong>ENTREGA Y FACTURACIÓN</strong></div>
    <p>
        Introduce la casilla del Cliente para ver los paquetes actuales:</p>
    <p>
        <asp:TextBox ID="txtcasilla" runat="server" Width="179px"></asp:TextBox>
    </p>
    <p>
        <asp:GridView ID="dgvpedidos" runat="server" BackColor="#66CCFF" 
            BorderColor="#000099" BorderStyle="Double">
        </asp:GridView>
    </p>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Buscar" />
    <br />
    <br />
    Ingrese el código del paquete que se entregará:<br />
    <br />
    <asp:TextBox ID="txtcod" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Lentregado" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        Text="Confirmar entrega" Width="164px" />
    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
        Text="Generar Factura" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    <br />
    <p align="right">
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Regresar" />
    </p>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" Visible="False" />
    </form>
</body>
</html>
