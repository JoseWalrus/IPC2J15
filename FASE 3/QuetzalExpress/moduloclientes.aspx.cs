using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

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
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        Lrecibidousa.Text=miwebserv.cargar_paquete_cliente_fecharecibido(txtpedido.Text);
        Lentransito.Text = miwebserv.cargar_paquete_cliente_fechaentransito(txtpedido.Text);
        Lenbodega.Text = miwebserv.cargar_paquete_cliente_fechaenbodega(txtpedido.Text);
        Lentregado.Text = miwebserv.cargar_paquete_cliente_fechaentregado(txtpedido.Text);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/UploadedImages/") + fileName);
            //Response.Redirect(Request.Url.AbsoluteUri);
            QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
            miwebserv.add_imagen(Server.MapPath("~/UploadedImages/") + fileName,txtcimg.Text);
            Lcarga.Text = "La ha carga a sido exitosa.";

        }
        else
        {
            Lcarga.Text = "No hay ningún archivo para cargar.";
        }

    }

    protected void Upload(object sender, EventArgs e)
    {
       
    }
}