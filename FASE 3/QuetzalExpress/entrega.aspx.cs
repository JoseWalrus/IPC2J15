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

public partial class entrega : System.Web.UI.Page
{
    QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        String cas = miwebserv.getcasilla_cliente(txtcasilla.Text);
        DataSet DS = miwebserv.cargar_pedidos_empleado(cas);
        dgvpedidos.DataSource = DS;
        dgvpedidos.DataMember = DS.Tables[0].TableName;
        dgvpedidos.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("moduloempleadoservicio.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        miwebserv.update_estado(txtcod.Text);
        Lentregado.Text="El paquete ha sido entregado exitosamente.";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        String articulo = miwebserv.getarticulo(txtcod.Text);
        String precio = miwebserv.getprecio(txtcod.Text);
        ReportDocument cryRpt;
        cryRpt = new ReportDocument();

        cryRpt.Load(@"C:\Users\-JoseWalrus\Documents\Visual Studio 2010\WebSites\QuetzalExpress\Factura.rpt");
        ParameterFieldDefinitions crParameterFieldDefinitions;
        ParameterFieldDefinition crParameterFieldDefinition;
        ParameterValues crParameterValues;
        ParameterDiscreteValue crParameterDiscreteValue;

        crParameterValues = new ParameterValues();
        crParameterDiscreteValue = new ParameterDiscreteValue();

        crParameterDiscreteValue.Value = precio; // TextBox con el valor del Parametro
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
        crParameterFieldDefinition = crParameterFieldDefinitions["total"];

        crParameterValues = crParameterFieldDefinition.CurrentValues;

        crParameterValues.Clear();
        crParameterValues.Add(crParameterDiscreteValue);
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        
        cryRpt.Load(@"C:\Users\-JoseWalrus\Documents\Visual Studio 2010\WebSites\QuetzalExpress\Factura.rpt");
        CrystalReportViewer1.ReportSource = cryRpt;
        CrystalReportViewer1.RefreshReport();
        cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\-JoseWalrus\Desktop\Factura.pdf");
        Label2.Text = "El PDF ha sido generado en su escritorio.";
    }
}