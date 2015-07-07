using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class accesoempleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string usuario = TextBox1.Text;
        string pass = TextBox2.Text;
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        Label1.Text = miwebserv.Loginempleado(usuario, pass).ToString();
        if (Label1.Text == "El empleado es valido y es administrador")
        {
            Response.Redirect("moduloadministrador.aspx");
        }
        else if (Label1.Text == "El empleado es valido y es director")
        {
            Response.Redirect("modulodirector.aspx");
        }
        else if (Label1.Text == "El empleado es valido y es registro")
        {
            Response.Redirect("moduloempleado.aspx");
        }
        else if (Label1.Text == "El empleado es valido y es bodega")
        {
            Response.Redirect("moduloempleadobodega.aspx");
        }
        else if (Label1.Text == "El empleado es valido y es servicio")
        {
            Response.Redirect("moduloempleadoservicio.aspx");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}