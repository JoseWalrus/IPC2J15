using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class registroclientes : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(cadena);

        string ad = "insert into Cliente values (@dpi,@nombre,@apellido,@NIT,@telefono,@direccion,@autorizado,@email,@pass,@casilla)";
        SqlCommand cmd = new SqlCommand(ad, con);
        con.Open();

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@dpi", SqlDbType.BigInt).Value = Convert.ToInt64(txtdpi.Text);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 150).Value = txtnombre.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 150).Value = txtapellido.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@NIT", SqlDbType.Int).Value = Convert.ToInt32(txtnit.Text);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = Convert.ToInt32(txttelefono.Text);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 150).Value = txtdireccion.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@autorizado", SqlDbType.Bit).Value = "True";

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = txtemail.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@pass", SqlDbType.VarChar, 150).Value = txtpass.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@casilla", SqlDbType.Int).Value = rnd.Next(100000, 999999);

        cmd.ExecuteNonQuery();

        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where dpi='" + txtdpi.Text + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Cliente");
        DataTable TablaCliente = DS.Tables[0];
        string cod = TablaCliente.Rows[0]["cod_cliente"].ToString();
      

        string tj = "insert into Tarjeta values (@cod_cliente,@numero,@fecha_venc,@cod_sec)";
        SqlCommand cmt = new SqlCommand(tj, con);

        cmt.CommandType = CommandType.Text;
        cmt.Parameters.Add("@cod_cliente", SqlDbType.Int).Value = Convert.ToInt32(cod);

        cmt.CommandType = CommandType.Text;
        cmt.Parameters.Add("@numero", SqlDbType.BigInt).Value = Convert.ToInt64(txttarjeta.Text);

        cmt.CommandType = CommandType.Text;
        cmt.Parameters.Add("@fecha_venc", SqlDbType.VarChar, 150).Value = txtfecha.Text;

        cmt.CommandType = CommandType.Text;
        cmt.Parameters.Add("@cod_sec", SqlDbType.BigInt).Value = Convert.ToInt64(txtseg.Text);

        cmt.ExecuteNonQuery();

        con.Close();

        txtdpi.Text = "";
        txtapellido.Text = "";
        txtdireccion.Text = "";
        txtemail.Text = "";
        txtfecha.Text = "";
        txtnit.Text = "";
        txtnombre.Text = "";
        txtpass.Text = "";
        txtseg.Text = "";
        txttarjeta.Text = "";
        txttelefono.Text = "";
        

    }
}