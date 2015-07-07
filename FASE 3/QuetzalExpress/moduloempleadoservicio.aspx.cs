using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class moduloempleadoservicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("entrega.aspx");
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("busquedacliente.aspx");
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("accesoempleados.aspx");
    }
}