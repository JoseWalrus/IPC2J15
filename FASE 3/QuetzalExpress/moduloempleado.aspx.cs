using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class moduloempleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        Lcod_actual.Text = miwebserv.getloteactual();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("entrega.aspx");
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("registrarpaquete.aspx"); 
    }
    protected void Button6_Click(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        miwebserv.update_lote();
    }
}