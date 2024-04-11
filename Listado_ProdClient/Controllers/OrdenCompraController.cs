using Microsoft.AspNetCore.Mvc;



using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Listado_ProdClient.Models;

namespace Listado_ProdClient.Controllers
{
    public class OrdenCompraController : Controller
    {
        public readonly IConfiguration Configuration;

        public OrdenCompraController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrdenCompra> listaOCxProveedor(string proveedor)
        {
            List<OrdenCompra> aOrdenCxProv = new List<OrdenCompra>();

            SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);

            cn.Open();

                SqlCommand cmd = new SqlCommand("SP_LISTAR_ORDENESCOMPRAxPROVEEDOR", cn);
                
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prov", proveedor);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
            {
                aOrdenCxProv.Add(new OrdenCompra()
                {
                    num_oco = int.Parse(dr[0].ToString()),
                    fec_oco = DateTime.Parse(dr[1].ToString()),
                    proveedor = dr[2].ToString(),
                    fec_ate = DateTime.Parse(dr[3].ToString())
                });
            }

            cn.Close();

            return aOrdenCxProv;
        }

        public IActionResult listadoOrdenCompraXProveedor(string prv = "")
        {
            if (string.IsNullOrEmpty(prv))
            {
                prv = "";
            }
            ViewBag.valorIngresado = prv;

            return View(listaOCxProveedor(prv));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
