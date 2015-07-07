using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

public partial class modulodirector : System.Web.UI.Page
{
    String arch;
    QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (ChecarExtension(FileUpload1.FileName))
            {
                FileUpload1.SaveAs(MapPath("Archivos/" + FileUpload1.FileName));
                arch = MapPath("Archivos/" + FileUpload1.FileName);
                StreamReader lector = new StreamReader(arch);
                String fila = String.Empty;
                lector.ReadLine();
                do
                {
                    fila = lector.ReadLine();
                    if (fila == null)
                    {
                        break;
                    }
                    String[] campos = fila.Split(',');
                    if (campos[3] == "Miami FL" && campos[4] == "Registro")
                    {
                        miwebserv.add_empleado(campos[0], campos[1], 0, 2, 1);
                    }
                    else if (campos[3] == "Miami FL" && campos[4] == "Servicio al Cliente")
                    {
                        miwebserv.add_empleado(campos[0], campos[1], 0, 3, 2);
                    }
                    else if (campos[3] == "Miami FL" && campos[4] == "Bodega")
                    {
                        miwebserv.add_empleado(campos[0], campos[1], 0, 4, 3);
                    }
                    else if (campos[3] == "Ciudad de Guatemala" && campos[4] == "Registro")
                    {
                        miwebserv.add_empleado(campos[0], campos[1], 0, 5, 1);
                    }
                    else if (campos[3] == "Ciudad de Guatemala" && campos[4] == "Servicio al Cliente")
                    {
                        miwebserv.add_empleado(campos[0], campos[1], 0, 6, 2);
                    }
                    else if (campos[3] == "Ciudad de Guatemala" && campos[4] == "Bodega")
                    {
                        miwebserv.add_empleado(campos[0], campos[1], 0, 7, 3);
                    }


                }
                while (true);
                Label1.Text = "¡CSV Impuesto cargado con exito!";
            }
        }
        else
        {
            Label1.Text = "Error en el archivo o no es de un formato valido";
        }
    }

    public bool ChecarExtension(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".csv":
                return true;
            default:
                return false;
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        txtprecio.Text = miwebserv.buscar_precio_parcial(txtcimg.Text);
        String imagencod = miwebserv.buscar_imagen_por_codigo(txtcimg.Text);
        string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadedImages/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            files.Add(new ListItem(fileName, "~/UploadedImages/" + fileName));
        }
        GridView1.DataSource = files;
        GridView1.DataBind();
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        miwebserv.update_precio(txtcimg.Text, txtprecio.Text);
    }
    protected void Button4_Click(object sender, System.EventArgs e)
    {
        DataSet DS = miwebserv.cargar_empleado_departamento(txtcoddepto.Text);
        dgvempleados.DataSource = DS;
        dgvempleados.DataMember = DS.Tables[0].TableName;
        dgvempleados.DataBind();
    }
    protected void Button13_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}