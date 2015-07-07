using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class moduloempleadobodega : System.Web.UI.Page
{
    QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("accesoempleados.aspx");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        //String imagencod = miwebserv.buscar_imagen_por_codigo(txtcimg.Text);
        string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadedImages/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            files.Add(new ListItem(fileName, "~/UploadedImages/"+fileName));
        }
        GridView1.DataSource = files;
        GridView1.DataBind();
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        miwebserv.update_imagen(txtcimg.Text, txtprecio.Text);
    }
}