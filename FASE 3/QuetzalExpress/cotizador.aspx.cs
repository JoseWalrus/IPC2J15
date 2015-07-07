using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class cotizador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader dr;
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(cadena);
        con.Open();
        SqlCommand com = new SqlCommand(" Select nombre From Impuesto", con);
        dr = com.ExecuteReader();
        ddl1.Items.Clear();
        while (dr.Read())
        {
            ddl1.Items.Add(dr[0].ToString());
        }
        ddl1.Visible = true;
        dr.Close();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Double USAD = 0;
        Double lb = 0.0;
        int lbreal = 0;
        int Q = 0;
        int impuesto = 0;
        Double impuestoaplicado;
        int lbcomision;
        Double total;

        USAD = Convert.ToInt32(TextBox1.Text);
        lb = Convert.ToDouble(TextBox1.Text);
        lbreal = (int)Convert.ToDouble(lb);
        Q = (int)Convert.ToDouble(USAD) * 8;
        String imp = ddl1.Text;
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Impuesto where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Impuesto");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["porcentaje"].ToString();
        impuesto = Convert.ToInt32(cod);
        lbreal = (int)Convert.ToDouble(lb);
        impuestoaplicado = Q * impuesto / 100 ;
        lbcomision = lbreal * 5;
        total = Q + lbcomision + impuestoaplicado;

        Label1.Text = "El total a pagar por el producto será: " + total.ToString() + ".";

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("moduloclientes.aspx");
    }
}
