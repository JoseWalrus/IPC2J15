using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

public partial class registrarpaquete : System.Web.UI.Page
{
    Double USAD = 0;
    Double lb = 0.0;
    int lbreal = 0;
    int Q = 0;
    int impuesto = 0;
    int comision = 0;
    int descuento = 0;
    Double impuestoaplicado;
    Double descuentoaplicado;
    int lbcomision;
    Double total;

    protected void Page_Load(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        Lloteactual.Text = miwebserv.getloteactual();
        get_impuesto();
        get_comision();
        get_descuento();
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
  

        USAD = Convert.ToDouble(txtpreciousa.Text);
        lb = Convert.ToDouble(txtpeso.Text);
        lbreal = (int)Convert.ToDouble(lb);
        Q = (int)Convert.ToDouble(USAD) * 8;
        String imp = ddl1.Text; 
        //Label1.Text = imp;
        String cod = aplicar_impuesto(imp);
        String com = ddl2.Text;
        String cod2 = aplicar_comision(com);
        String des = ddl3.Text;
        String cod3 = aplicar_descuento(des);
        impuesto = Convert.ToInt32(cod);
        comision = Convert.ToInt32(cod2);
        descuento = Convert.ToInt32(cod3);
        lbreal = (int)Convert.ToDouble(lb);
        impuestoaplicado = Q * impuesto / 100;
        descuentoaplicado = Q * descuento / 100;
        lbcomision = lbreal * comision;
        Double totalparcial = Q + lbcomision + impuestoaplicado;
        total = totalparcial - descuentoaplicado;

        txttotal.Text = total.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("moduloempleado.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        QuetzalReference.ServiceSoapClient miwebserv = new QuetzalReference.ServiceSoapClient();
        
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(cadena);
        string ad = "insert into Pedido values (@cod_cliente,@nombre,@precio_USA,@cod_impuestos,@cod_comision,@cod_descuento,@total,@peso_libra,@devolucion,@estado)";
        SqlCommand cmd = new SqlCommand(ad, con);
        con.Open();

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@cod_cliente", SqlDbType.BigInt).Value = Convert.ToInt64(getcasilla(txtcasilla.Text));

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 150).Value = txtnombre.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@precio_USA", SqlDbType.Money).Value = txtpreciousa.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@cod_impuestos", SqlDbType.Int).Value = getcod_impuesto(ddl1.SelectedItem.Text);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@cod_comision", SqlDbType.Int).Value = getcod_comision(ddl2.SelectedItem.Text);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@cod_descuento", SqlDbType.Int).Value = getcod_descuento(ddl3.SelectedItem.Text);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@total", SqlDbType.Money).Value = txttotal.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@peso_libra", SqlDbType.Money).Value = txtpeso.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@devolucion", SqlDbType.Bit).Value = "False";

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@estado", SqlDbType.VarChar, 150).Value = "Recibido en USA";


        cmd.ExecuteNonQuery();

        string ad2 = "insert into Control_pedido values (@fecha_adicion,@cod_pedido,@cod_lote,@estado)";
        SqlCommand cmd2 = new SqlCommand(ad2, con);
        

        cmd2.CommandType = CommandType.Text;
        cmd2.Parameters.Add("@fecha_adicion", SqlDbType.DateTime).Value = DateTime.Now;

        cmd2.CommandType = CommandType.Text;
        cmd2.Parameters.Add("@cod_pedido", SqlDbType.VarChar, 150).Value = miwebserv.getcodpedido(getcasilla(txtcasilla.Text), txtnombre.Text, txttotal.Text);

        cmd2.CommandType = CommandType.Text;
        cmd2.Parameters.Add("@cod_lote", SqlDbType.Money).Value = miwebserv.getloteactual();

        cmd2.CommandType = CommandType.Text;
        cmd2.Parameters.Add("@estado", SqlDbType.VarChar, 100).Value = "Recibido en USA";

        cmd2.ExecuteNonQuery();



        txtcasilla.Text = "";
        txtnombre.Text = "";
        txtpeso.Text = "";
        txtpreciousa.Text = "";
        txttotal.Text = "";

        Linforme.Text = "El registro ha sido añadido exitosamente al Lote: " + miwebserv.getloteactual();

    }

    public void get_impuesto() 
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

    public void get_comision()
    {
        SqlDataReader dr;
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(cadena);
        con.Open();

        SqlCommand com = new SqlCommand(" Select nombre From Comision", con);
        dr = com.ExecuteReader();
        ddl2.Items.Clear();
        while (dr.Read())
        {
            ddl2.Items.Add(dr[0].ToString());
        }
        ddl2.Visible = true;
        dr.Close();
        con.Close();
    }

    public void get_descuento()
    {
        SqlDataReader dr;
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(cadena);
        con.Open();

        SqlCommand com = new SqlCommand(" Select nombre From Descuento", con);
        dr = com.ExecuteReader();
        ddl3.Items.Clear();
        while (dr.Read())
        {
            ddl3.Items.Add(dr[0].ToString());
        }
        ddl3.Visible = true;
        dr.Close();
        con.Close();
    }

    public String aplicar_impuesto(string imp)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Impuesto where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Impuesto");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["porcentaje"].ToString();

        return cod;
    }

    public String aplicar_comision(string imp)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Comision where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Comision");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["porcentaje"].ToString();

        return cod;
    }

    public String aplicar_descuento(string imp)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Descuento where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Descuento");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["porcentaje"].ToString();

        return cod;
    }

    public String getcod_impuesto(string imp)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Impuesto where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Impuesto");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_impuesto"].ToString();

        return cod;
    }

    public String getcod_comision(string imp)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Comision where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Comision");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_comision"].ToString();

        return cod;
    }

    public String getcod_descuento(string imp)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Descuento where nombre='" + imp + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Descuento");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_descuento"].ToString();

        return cod;
    }

    public String getcasilla(string casilla)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where casilla='" + casilla + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Casilla");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_cliente"].ToString();

        return cod;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

    }
}