using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class moduloclientes : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        DataSet DS = miwebserv.cargar_pedidos_cliente();
        dgvpedidos.DataSource = DS;
        dgvpedidos.DataMember = DS.Tables[0].TableName;
        dgvpedidos.DataBind();
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("cotizador.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("editar_perfil.aspx");
    }
}