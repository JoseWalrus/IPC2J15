using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string usuario = TextBox1.Text;
        string pass = TextBox2.Text;
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        Label1.Text=miwebserv.Logincliente(usuario, pass).ToString();
        if (Label1.Text == "true")
        {
            Response.Redirect("moduloclientes.aspx");
        }
        




    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("accesoempleados.aspx");
    }
}