using Microsoft.AspNetCore.Mvc;

using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Listado_ProdClient.Models;
using Microsoft.Identity.Client;

namespace Listado_ProdClient.Controllers
{
    public class ProveedorController : Controller
    {
        public readonly IConfiguration Configuration;

        public ProveedorController(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }

        public List<Proveedor> listaProveedores()
        {
            List<Proveedor> aProveedores = new List<Proveedor>();   
            {
                SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);
                
                cn.Open();

                SqlCommand cmd = new SqlCommand("SP_LISTAR_PROVEEDORES", cn);

                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aProveedores.Add(new Proveedor()
                    {
                        ide_prv = int.Parse(dr[0].ToString()),
                        raz_soc_prv = dr[1].ToString(),
                        dir_prv = dr[2].ToString(),
                        tel_prv = dr[3].ToString(),
                        nom_dis = dr[4].ToString(),
                        rep_ven = dr[5].ToString(),
                    });
                }

                cn.Close();
            }
            return aProveedores;
        }

        public IActionResult listaProveedor()
        {
            return View(listaProveedores());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
