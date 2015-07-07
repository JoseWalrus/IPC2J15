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


public partial class moduloadministrador : System.Web.UI.Page
{
    QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
    String arch;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        

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
                    miwebserv.add_impuesto(campos[0], Convert.ToInt32(campos[1].Trim(new Char[] { '%' })));

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
    protected void Button7_Click(object sender, EventArgs e)
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
                        miwebserv.add_empleado(campos[0], campos[1], 0 , 2, 1);
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
    protected void Button9_Click(object sender, EventArgs e)
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
                    miwebserv.add_pedido(Convert.ToInt32(miwebserv.buscar_codigo_cliente(campos[1])),Convert.ToInt32(miwebserv.buscar_codigo_impuesto(campos[0])),Convert.ToInt32(campos[2]),Convert.ToDouble(campos[3]));
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
    protected void Button10_Click(object sender, EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(@"C:\Users\-JoseWalrus\Documents\Visual Studio 2010\WebSites\QuetzalExpress\Paquetes_por_categoria.rpt");
        CrystalReportViewer1.ReportSource = cryRpt;
        CrystalReportViewer1.RefreshReport();
        cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\-JoseWalrus\Desktop\Paquetes_por_categoria.pdf");
        Label2.Text = "El PDF ha sido generado en su escritorio.";
    }
    protected void Button12_Click(object sender, System.EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(@"C:\Users\-JoseWalrus\Documents\Visual Studio 2010\WebSites\QuetzalExpress\Empleado_por_depto.rpt");
        CrystalReportViewer1.ReportSource = cryRpt;
        CrystalReportViewer1.RefreshReport();
        cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\-JoseWalrus\Desktop\Empleado_por_depto.pdf");
        Label2.Text = "El PDF ha sido generado en su escritorio.";
    }
    protected void Button14_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void Button13_Click(object sender, System.EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(@"C:\Users\-JoseWalrus\Documents\Visual Studio 2010\WebSites\QuetzalExpress\top5.rpt");
        CrystalReportViewer1.ReportSource = cryRpt;
        CrystalReportViewer1.RefreshReport();
        cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\-JoseWalrus\Desktop\top5.pdf");
        Label2.Text = "El PDF ha sido generado en su escritorio.";
    }
    protected void Button11_Click(object sender, System.EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(@"C:\Users\-JoseWalrus\Documents\Visual Studio 2010\WebSites\QuetzalExpress\Paquete_por_sucursal.rpt");
        CrystalReportViewer1.ReportSource = cryRpt;
        CrystalReportViewer1.RefreshReport();
        cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\-JoseWalrus\Desktop\Paquete_por_sucursal.pdf");
        Label2.Text = "El PDF ha sido generado en su escritorio.";
    }
}