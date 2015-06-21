using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class editar_perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        DataSet DS = miwebserv.cargar_cliente();
        DataTable TablaCliente = DS.Tables[0];
        string nombre = TablaCliente.Rows[0]["nombre"].ToString();
        txtnombre.Text = nombre;
        string apellido = TablaCliente.Rows[0]["apellido"].ToString();
        txtapellido.Text = apellido;
        string telefono = TablaCliente.Rows[0]["telefono"].ToString();
        txttelefono.Text = telefono;
        string direccion = TablaCliente.Rows[0]["direccion"].ToString();
        txtdireccion.Text = direccion;
        DataSet DT = miwebserv.cargar_tarjeta();
        DataTable TablaTarjeta = DT.Tables[0];
        string tarjeta = TablaTarjeta.Rows[0]["numero"].ToString();
        txttarjeta.Text = tarjeta;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Atras_Click(object sender, EventArgs e)
    {
        Response.Redirect("moduloclientes.aspx");
    }
}