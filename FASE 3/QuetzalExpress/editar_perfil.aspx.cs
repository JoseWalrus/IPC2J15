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
        string dpi = TablaCliente.Rows[0]["dpi"].ToString();
        txtdpi.Text = dpi;
        string nombre = TablaCliente.Rows[0]["nombre"].ToString();
        txtnombre.Text = nombre;
        string apellido = TablaCliente.Rows[0]["apellido"].ToString();
        txtapellido.Text = apellido;
        string nit = TablaCliente.Rows[0]["NIT"].ToString();
        txtnit.Text = nit;
        string telefono = TablaCliente.Rows[0]["telefono"].ToString();
        txttelefono.Text = telefono;
        string direccion = TablaCliente.Rows[0]["direccion"].ToString();
        txtdireccion.Text = direccion;
        string email = TablaCliente.Rows[0]["email"].ToString();
        txtemail.Text = email;
        string pass = TablaCliente.Rows[0]["pass"].ToString();
        txtpass.Text = pass;
        DataSet DT = miwebserv.cargar_tarjeta();
        DataTable TablaTarjeta = DT.Tables[0];
        string tarjeta = TablaTarjeta.Rows[0]["numero"].ToString();
        txttarjeta.Text = tarjeta;
        string fecha = TablaTarjeta.Rows[0]["fecha_venc"].ToString();
        txtfecha.Text = fecha;
        string seg = TablaTarjeta.Rows[0]["cod_sec"].ToString();
        txtseg.Text = seg;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(cadena);

        string ad = "update Cliente set nombre= @nombre, apellido= @apellido, NIT=@nit, telefono=@telefono, direccion=@direccion, email=@email, pass=@pass  where dpi=@dpi";
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
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = txtemail.Text;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@pass", SqlDbType.VarChar, 150).Value = txtpass.Text;

        cmd.ExecuteNonQuery();

       /*/ SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where dpi='" + txtdpi.Text + "'", con);
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

        cmt.ExecuteNonQuery();/*/

        con.Close();
    }
    protected void Atras_Click(object sender, EventArgs e)
    {
        Response.Redirect("moduloclientes.aspx");
    }
}