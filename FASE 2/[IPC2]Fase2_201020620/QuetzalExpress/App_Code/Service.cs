using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

[WebService(Namespace = "http://quetzalexpress.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public static int cod_cliente;
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public int getcod_cliente()
    {
        return cod_cliente;
    }

    [WebMethod]
    public DataSet cargar_pedidos_cliente()
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Pedido where cod_cliente='" + cod_cliente + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Pedido");
        return DS;
    }

    [WebMethod]
    public DataSet cargar_cliente()
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where cod_cliente='" + cod_cliente + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Cliente");
        return DS;
    }

    [WebMethod]
    public DataSet cargar_tarjeta()
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Tarjeta where cod_cliente='" + cod_cliente + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Tarjeta");
        return DS;
    }

    [WebMethod]
    public String Logincliente(String email, String pass)
    {
        String resultado;
        resultado = "";
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where email='"+ email +"' AND pass='"+ pass +"'",con);
        SqlCommand cnd = new SqlCommand("select *from Cliente where email='"+ email +"' AND pass='"+ pass +"'",con);
        SqlDataReader dr;
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Datos");
        DataTable TablaEmpleado = DS.Tables[0];
        dr = cnd.ExecuteReader();
        int count = 0;
        while (dr.Read())
        {
            count += 1;
        }

        if (count == 1)
        {
            string cod = TablaEmpleado.Rows[0]["cod_cliente"].ToString();
            cod_cliente = Convert.ToInt32(cod);
            resultado = "true";

        }
        else if (count < 0)
        {
            resultado = "El usuario o contraseña están repetidos";
        }
        else
        {
            resultado = "El usuario no existe";
        }
       
        return resultado;
    }

    [WebMethod]
    public string Loginempleado(String email, String pass)
    {
        String resultado;
        resultado = "";
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Empleado where email='" + email + "' AND pass='" + pass + "'", con);
        SqlCommand cnd = new SqlCommand("select *from Empleado where email='" + email + "' AND pass='" + pass + "'", con);
        SqlDataReader dr;
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Datos");
        DataTable TablaEmpleado = DS.Tables[0];
        dr = cnd.ExecuteReader();
        int count = 0;
        while (dr.Read())
        {
            count += 1;
        }

        if (count == 1)
        {
            string admin = TablaEmpleado.Rows[0]["administrador"].ToString();
            string direc = TablaEmpleado.Rows[0]["director"].ToString();
            if (admin == "True")
            {
                resultado = "El empleado es valido y es administrador";
            }
            else if (direc == "True")
            {
                resultado = "El empleado es valido y es director";
            }
            else
            {
                resultado = "El empleado es valido y tiene privilegios limitados";
            }
            

        }
        else if (count < 0)
        {
            resultado = "El usuario o contraseña están repetidos";
        }
        else
        {
            resultado = "El usuario no existe";
        }

        return resultado;
    }
    
}