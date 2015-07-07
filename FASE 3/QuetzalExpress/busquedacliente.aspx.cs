using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class busquedacliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        Lcasillacliente.Text = miwebserv.buscar_casilla_cliente(txtdpi.Text,txtnombre.Text,txtapellido.Text).ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("moduloempleado.aspx");
    }
}