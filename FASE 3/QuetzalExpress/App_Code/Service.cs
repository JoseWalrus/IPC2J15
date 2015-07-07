using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

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
    public String getcodpedido(String cod_cliente, String nombre, String total)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Pedido where cod_cliente='" + cod_cliente + "' AND nombre='" + nombre + "'AND total='" + total + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Pedido");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_pedido"].ToString();
        return cod;
    }

    [WebMethod]
    public String getloteactual()
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from pedido_actual where cod_pedido_actual='1'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Lote");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_actual"].ToString();
        return cod;
    }

    [WebMethod]
    public String getarticulo(String cod3)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Pedido where cod_pedido='"+ cod3 +"'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Pedido");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["nombre"].ToString();
        return cod;
    }

    [WebMethod]
    public String getprecio(String cod3)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Pedido where cod_pedido='" + cod3 + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Pedido");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["total"].ToString();
        return cod;
    }

    [WebMethod]
    public string getcasilla_cliente(string casilla)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where casilla='" + casilla + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Cliente");
        DataTable TablaEmpleado = DS.Tables[0];
        string cod = TablaEmpleado.Rows[0]["cod_cliente"].ToString();
        return cod;
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
    public DataSet cargar_empleado_departamento(String codempleado)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Empleado where cod_depto='" + codempleado + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Empleado");
        return DS;
    }

    [WebMethod]
    public String cargar_paquete_cliente_fecharecibido(String cod_pedido)
    {
        string cod;
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Control_pedido where cod_pedido='" + cod_pedido + "'AND estado='" + "Recibido en USA" + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Control");
        DataTable TablaEmpleado = DS.Tables[0];
        if (DS.Tables[0].Rows.Count > 0)
        {
            cod = "El paquete con código " + cod_pedido + " fue recibido en USA en " + TablaEmpleado.Rows[0]["fecha_adicion"].ToString();
            
        }
        else
        {
            cod = "El paquete no ha sido Recibido en USA";
        }
        return cod;
    }

    [WebMethod]
    public String cargar_paquete_cliente_fechaentransito(String cod_pedido)
    {
        string cod;
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Control_pedido where cod_pedido='" + cod_pedido + "'AND estado='" + "En transito" + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Control");
        DataTable TablaEmpleado = DS.Tables[0];
        if (DS.Tables[0].Rows.Count > 0)
        {
            
            cod = "El paquete con código " + cod_pedido + " dejó nuestro sucursal en USA en " + TablaEmpleado.Rows[0]["fecha_adicion"].ToString();

        }
        else
        {
            cod = "El paquete no ha dejado nuestra sucursal en USA";
        }
        return cod;
    }

    [WebMethod]
    public String cargar_paquete_cliente_fechaenbodega(String cod_pedido)
    {
        string cod;
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Control_pedido where cod_pedido='" + cod_pedido + "'AND estado='" + "En bodega" + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Control");
        DataTable TablaEmpleado = DS.Tables[0];
        if (DS.Tables[0].Rows.Count > 0)
        {

            cod = "El paquete con código " + cod_pedido + " ingresó a nuestras bodegas en Guatemala en " + TablaEmpleado.Rows[0]["fecha_adicion"].ToString();

        }
        else
        {
            cod = "El paquete no ha ingresado a nuestras bodegas en Guatemala";
        }
        return cod;
    }

    [WebMethod]
    public String cargar_paquete_cliente_fechaentregado(String cod_pedido)
    {
        string cod;
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Control_pedido where cod_pedido='" + cod_pedido + "'AND estado='" + "Entregado" + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Control");
        DataTable TablaEmpleado = DS.Tables[0];
        if (DS.Tables[0].Rows.Count > 0)
        {

            cod = "El paquete con código " + cod_pedido + " fue entregado en " + TablaEmpleado.Rows[0]["fecha_adicion"].ToString();

        }
        else
        {
            cod = "El paquete no ha sido entregado";
        }
        return cod;
    }


    [WebMethod]
    public String buscar_casilla_cliente(string dpi, string nombre, string apellido)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where dpi='" + dpi + "' AND nombre='" + nombre + "'AND apellido='" + apellido + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Cliente");
        DataTable TablaCliente = DS.Tables[0];
        string cod = TablaCliente.Rows[0]["casilla"].ToString();
        return cod;
    }

    [WebMethod]
    public String buscar_imagen_por_codigo(string cod_pedido)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from imagen where cod_pedido='" + cod_pedido + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "img");
        DataTable TablaCliente = DS.Tables[0];
        string cod = TablaCliente.Rows[0]["ubicacion"].ToString();
        return cod;
    }

    [WebMethod]
    public String buscar_codigo_cliente(string casilla)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Cliente where casilla='" + casilla + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Cliente");
        DataTable TablaCliente = DS.Tables[0];
        string cod = TablaCliente.Rows[0]["cod_cliente"].ToString();
        return cod;
    }

    [WebMethod]
    public String buscar_precio_parcial(string cod2)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from imagen where cod_pedido='" + cod2 + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Imagen");
        DataTable TablaCliente = DS.Tables[0];
        string cod = TablaCliente.Rows[0]["precio_aprobar"].ToString();
        return cod;
    }

    [WebMethod]
    public String buscar_codigo_impuesto(string nombre)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Impuesto where nombre='" + nombre + "'", con);
        DataSet DS = new DataSet();
        CMD.Fill(DS, "Impuesto");
        DataTable TablaCliente = DS.Tables[0];
        string cod = TablaCliente.Rows[0]["cod_impuesto"].ToString();
        return cod;
    }

    [WebMethod]
    public DataSet cargar_pedidos_empleado(string casilla)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Pedido where cod_cliente='" + casilla + "' AND estado='En Bodega'", con);
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
            string tipoempleado = TablaEmpleado.Rows[0]["cod_puesto"].ToString();
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
                if (tipoempleado == "1")
                {
                    resultado = "El empleado es valido y es registro";
                }
                else if (tipoempleado == "2")
                {
                    resultado = "El empleado es valido y es bodega";
                }
                else
                {
                    resultado = "El empleado es valido y es servicio";
                }
                
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

    [WebMethod]
    public void update_estado(String cod)
    {
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection conexionSql = new SqlConnection(cadena);
        try
        {
            string cmd = "update Pedido set estado= @estado where cod_pedido=@cod_pedido";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = cmd;
            sqlCmd.Connection = conexionSql;
            sqlCmd.CommandType = CommandType.Text;
            SqlParameter par_estado = sqlCmd.Parameters.Add("@estado", SqlDbType.VarChar);
            SqlParameter par_cod_pedido = sqlCmd.Parameters.Add("@cod_pedido", SqlDbType.VarChar);
            par_estado.Value = ("Entregado");
            par_cod_pedido.Value = cod;
            conexionSql.Open();
            sqlCmd.ExecuteNonQuery();
            conexionSql.Close();
        }
        catch (Exception ex)
        {
           
        }
    }

    [WebMethod]
    public void update_precio(String cod, String precio)
    {
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection conexionSql = new SqlConnection(cadena);
        try
        {
            string cmd = "update Pedido set precio_USA= @precio_USA where cod_pedido=@cod_pedido";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = cmd;
            sqlCmd.Connection = conexionSql;
            sqlCmd.CommandType = CommandType.Text;
            SqlParameter par_precio = sqlCmd.Parameters.Add("@precio_USA", SqlDbType.VarChar);
            SqlParameter par_cod_pedido = sqlCmd.Parameters.Add("@cod_pedido", SqlDbType.VarChar);
            par_precio.Value = precio;
            par_cod_pedido.Value = cod;
            conexionSql.Open();
            sqlCmd.ExecuteNonQuery();
            conexionSql.Close();
        }
        catch (Exception ex)
        {

        }
    }

    [WebMethod]
    public void update_imagen(String cod, String precio)
    {
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection conexionSql = new SqlConnection(cadena);
        try
        {
            string cmd = "update imagen set precio_aprobar= @precio_aprobar where cod_pedido=@cod_pedido";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = cmd;
            sqlCmd.Connection = conexionSql;
            sqlCmd.CommandType = CommandType.Text;
            SqlParameter par_precio_aprobar = sqlCmd.Parameters.Add("@precio_aprobar", SqlDbType.VarChar);
            SqlParameter par_cod_pedido = sqlCmd.Parameters.Add("@cod_pedido", SqlDbType.VarChar);
            par_precio_aprobar.Value = precio;
            par_cod_pedido.Value = cod;
            conexionSql.Open();
            sqlCmd.ExecuteNonQuery();
            conexionSql.Close();
        }
        catch (Exception ex)
        {

        }
    }

    
    

    [WebMethod]
    public void update_lote()
    {
        string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection conexionSql = new SqlConnection(cadena);
        int actual = Convert.ToInt32(getloteactual());
        int nuevoactual = actual + 1;
        SqlConnection con = new SqlConnection(cadena);
        string ad = "insert into Lote values (@fecha_envio,@fecha_recibido)";
        SqlCommand cmd0 = new SqlCommand(ad, con);
        con.Open();

        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.Add("@fecha_envio", SqlDbType.DateTime).Value = DateTime.Now;

        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.Add("@fecha_recibido", SqlDbType.DateTime).Value = DateTime.Now;

        cmd0.ExecuteNonQuery();

        try
        {
            string cmd = "update pedido_actual set cod_actual= @cod_actual where cod_pedido_actual=@cod_pedido_actual";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = cmd;
            sqlCmd.Connection = conexionSql;
            sqlCmd.CommandType = CommandType.Text;
            SqlParameter par_codeactual = sqlCmd.Parameters.Add("@cod_actual", SqlDbType.VarChar);
            SqlParameter par_cod_pedido = sqlCmd.Parameters.Add("@cod_pedido_actual", SqlDbType.VarChar);
            par_codeactual.Value = nuevoactual.ToString();
            par_cod_pedido.Value = "1";
            conexionSql.Open();
            sqlCmd.ExecuteNonQuery();
            conexionSql.Close();
        }
        catch (Exception ex)
        {

        }
    }

     [WebMethod]
    public void update_lote_pedidos(int lote)
    {
        string conexion = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexion);
        con.Open();
        SqlDataAdapter CMD = new SqlDataAdapter("select *from Control_pedido where cod_lote='" + lote + "' AND estado='" + "Recibido en USA" + "'", con);
        DataSet DS = new DataSet();

        CMD.Fill(DS, "Lote");
        foreach(DataTable Table in DS.Tables)
        {
            DataTable TablaCliente = DS.Tables[0];
            string cod = TablaCliente.Rows[0]["casilla"].ToString();
            string ad2 = "insert into Control_pedido values (@fecha_adicion,@cod_pedido,@cod_lote,@estado)";
            SqlCommand cmd2 = new SqlCommand(ad2, con);


            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("@fecha_adicion", SqlDbType.DateTime).Value = DateTime.Now;

            cmd2.CommandType = CommandType.Text;
            //cmd2.Parameters.Add("@cod_pedido", SqlDbType.VarChar, 150).Value = miwebserv.getcodpedido(getcasilla(txtcasilla.Text), txtnombre.Text, txttotal.Text);

            cmd2.CommandType = CommandType.Text;
            //cmd2.Parameters.Add("@cod_lote", SqlDbType.Money).Value = miwebserv.getloteactual();

            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("@estado", SqlDbType.VarChar, 100).Value = "Recibido en USA";

            cmd2.ExecuteNonQuery();
        }
        
        
    }

     [WebMethod]
     public void add_imagen(String ubicacion, String cod_p)
     {
         string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
         SqlConnection conexionSql = new SqlConnection(cadena);
         SqlConnection con = new SqlConnection(cadena);
         string ad = "insert into imagen values (@ubicacion,@cod_pedido,@precio_aprobar)";
         SqlCommand cmd0 = new SqlCommand(ad, con);
         con.Open();

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@ubicacion", SqlDbType.VarChar, 150).Value = ubicacion;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_pedido", SqlDbType.Int).Value = cod_p;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@precio_aprobar", SqlDbType.Money).Value = "0";

         cmd0.ExecuteNonQuery();
     }

     [WebMethod]
     public void add_impuesto(String nombre, int porcentaje)
     {
         string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
         SqlConnection conexionSql = new SqlConnection(cadena);
         SqlConnection con = new SqlConnection(cadena);
         string ad = "insert into Impuesto values (@nombre,@porcentaje,@descripcion)";
         SqlCommand cmd0 = new SqlCommand(ad, con);
         con.Open();

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@nombre", SqlDbType.VarChar, 150).Value = nombre;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@porcentaje", SqlDbType.Int).Value = porcentaje;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = "";

         cmd0.ExecuteNonQuery();
     }

     [WebMethod]
     public void add_empleado(String apellido, String nombre, int sueldo, int sucursal, int departamento)
     {
         string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
         SqlConnection conexionSql = new SqlConnection(cadena);
         SqlConnection con = new SqlConnection(cadena);
         string ad = "insert into Empleado values (@DPI,@nombre,@apellido,@telefono,@cod_puesto,@direccion,@email,@pass,@cod_depto,@director,@administrador)";
         SqlCommand cmd0 = new SqlCommand(ad, con);
         con.Open();

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@DPI", SqlDbType.VarChar, 150).Value = "";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@nombre", SqlDbType.VarChar, 150).Value = nombre;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@apellido", SqlDbType.VarChar, 150).Value = apellido;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@telefono", SqlDbType.Int).Value = 0;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_puesto", SqlDbType.Int).Value = departamento;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@direccion", SqlDbType.VarChar, 150).Value = "";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = apellido+nombre+sucursal.ToString()+departamento.ToString()+"@quetzalexpress.com";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@pass", SqlDbType.VarChar, 150).Value = "quetzalexpress123**";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_depto", SqlDbType.Int).Value = sucursal;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@director", SqlDbType.Bit).Value = "False";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@administrador", SqlDbType.Bit).Value = "False";


         cmd0.ExecuteNonQuery();
     }

     [WebMethod]
     public void add_pedido(int cod_cliente, int cod_impuesto, int peso, double precio)
     {
         string cadena = "Data Source=WALRUSBOOK;Initial Catalog=QUETZAL_EXPRESS;Integrated Security=True";
         SqlConnection conexionSql = new SqlConnection(cadena);
         SqlConnection con = new SqlConnection(cadena);
         string ad = "insert into Pedido values (@cod_cliente,@nombre,@precio_USA,@cod_impuesto,@cod_comision,@cod_descuento,@total,@peso_libra,@devolucion,@estado)";
         SqlCommand cmd0 = new SqlCommand(ad, con);
         con.Open();

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_cliente", SqlDbType.Int).Value = cod_cliente;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@nombre", SqlDbType.VarChar, 150).Value = "";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@precio_USA", SqlDbType.Money).Value = 0;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_impuesto", SqlDbType.Int).Value = cod_impuesto;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_comision", SqlDbType.Int).Value = 1;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@cod_descuento", SqlDbType.Int).Value = 2;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@total", SqlDbType.Money).Value = precio;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@peso_libra", SqlDbType.Int).Value = peso;

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@devolucion", SqlDbType.Bit).Value = "False";

         cmd0.CommandType = CommandType.Text;
         cmd0.Parameters.Add("@estado", SqlDbType.VarChar, 150).Value = "Recibido en USA";

         cmd0.ExecuteNonQuery();

         string ad2 = "insert into Control_pedido values (@fecha_adicion,@cod_pedido,@cod_lote,@estado)";
         SqlCommand cmd2 = new SqlCommand(ad2, con);

         cmd2.CommandType = CommandType.Text;
         cmd2.Parameters.Add("@fecha_adicion", SqlDbType.DateTime).Value = DateTime.Now;

         cmd2.CommandType = CommandType.Text;
         cmd2.Parameters.Add("@cod_pedido", SqlDbType.VarChar, 150).Value = getcodpedido(cod_cliente.ToString(), "", precio.ToString());

         cmd2.CommandType = CommandType.Text;
         cmd2.Parameters.Add("@cod_lote", SqlDbType.Money).Value = getloteactual();

         cmd2.CommandType = CommandType.Text;
         cmd2.Parameters.Add("@estado", SqlDbType.VarChar, 100).Value = "Recibido en USA";

         cmd2.ExecuteNonQuery();
     }
    

}