using Microsoft.AspNetCore.Mvc;

//PASO 1: Librerías ADO .NET
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Listado_ProdClient.Models;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Listado_ProdClient.Controllers
{
    public class ProductoController : Controller
    {
        //PASO 2: Variable de sólo lectura del tipo IConfiguration
        public readonly IConfiguration  Configuration;

        //PASO 3: Inyección de dependencias en el constructor para que el controller pueda acceder al archivo de configuración
        public ProductoController(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }

        //PASO 4: Función que retorne una lista de los productos
        public List<Producto> listaProducto()
        {
            //PASO 4.1: Lista que almacenará las facturas
            List<Producto> lProductos = new List<Producto>();

            //PASO 4.2: Definir la cadena de conexión
            SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);

            //PASO 4.3: Abrir la conexión
            cn.Open();

            //PASO 4.4: Llamar a la sentencia SQL y especificar la conexión a BD a usar
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PRODUCTOS", cn);

            //PASO 4.5: Especificar el tipo de sentencia SQL que se ejecutará (BUENA PRÁCTICA)  
            cmd.CommandType = System.Data.CommandType.Text;

            //PASO 4.6: Almacenar en un objeto de lectura la información que traiga la sentencia SQL.  - Aquí se inicia la ejecución del comando SQL
            SqlDataReader dr = cmd.ExecuteReader();

            //PASO 4.7: Leer la información traída con el método Read() el cuál lee los registros y se apoya del bucle While para avanzar al siguiente registro hasta llegar al último existente
            while (dr.Read())
            {
                //PASO 4.8: Añadir los objetos Productos(cada línea de registros traídos por el "dr") a la lista declarada, esto usando el método Add() de la lista
                lProductos.Add(new Producto()
                {
                    //PASO 4.9:Relacionar los atributos de la clase Producto con los datos de cada registro traído por el DataReader (representado por dr)
                    ide_pro = int.Parse(dr[0].ToString()),
                    des_pro = dr[1].ToString(),
                    pre_pro = Double.Parse(dr[2].ToString()),
                    sac_pro = int.Parse(dr[3].ToString()),
                    smi_pro = int.Parse(dr[4].ToString()),
                    uni_pro = dr[5].ToString()
                });
            }

            //PASO 5: Cerrar la conexión
            cn.Close();

            //PASO 6: Devolver la lista llena
            return lProductos;
        }


        /******* SESIÓN 3: Listado de Productos filtrado por la inicial de su descripción  *********/
        public List<Producto> listProductosXDescrip(string i_descrip)
        {
            List<Producto> listProdDescr = new List<Producto>();

            SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);

            cn.Open();

            SqlCommand cmd = new SqlCommand("SP_LISTAR_PRODUCTOSxDESCRIPCION", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@i_descrip", i_descrip);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listProdDescr.Add(new Producto()
                {
                    ide_pro = int.Parse(dr[0].ToString()),
                    des_pro = dr[1].ToString(),
                    pre_pro = Double.Parse(dr[2].ToString()),
                    sac_pro = int.Parse(dr[3].ToString()),
                    smi_pro = int.Parse(dr[4].ToString()),
                    uni_pro = dr[5].ToString()
                });
            }

            cn.Close();

            return listProdDescr;
        }

        public IActionResult listadoTablaProdutos()
        {
            return View(listaProducto());
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult listadoProductosXDescripcion(string i_descrip = "")
        {
            //acceder al método estático IsNullOrEmpty() de la clase string para validar el parámetro
            if (string.IsNullOrEmpty(i_descrip))
            {
                // Si el valor no cumple con los criterios, asigna un valor predeterminado
                i_descrip = "";
            }
            

            ViewBag.i_descrip = i_descrip;
            return View(listProductosXDescrip(i_descrip));
        }
    }
}
