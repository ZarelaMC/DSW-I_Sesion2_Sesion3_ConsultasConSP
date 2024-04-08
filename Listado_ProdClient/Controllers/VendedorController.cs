using Microsoft.AspNetCore.Mvc;

using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Listado_ProdClient.Models;

namespace Listado_ProdClient.Controllers
{
    public class VendedorController : Controller
    {
        public readonly IConfiguration Configuration;

        public VendedorController(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }

        public List<Vendedor> listaVendedor() {
            List<Vendedor> aVendedor = new List<Vendedor>();

            SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);

            cn.Open();

            SqlCommand cmd = new SqlCommand("SP_LISTAR_VENDEDORES", cn);

            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                aVendedor.Add(new Vendedor()
                {
                    id_ven = int.Parse(dr[0].ToString()),
                    ven = dr[1].ToString(),
                    sue_ven = double.Parse(dr[2].ToString()),
                    fec_ing = DateTime.Parse(dr[3].ToString()),
                    nom_dis = dr[4].ToString()
                });
            }

            cn.Close();

            return aVendedor;
        }


        public IActionResult listaVendedores()
        {
            return View(listaVendedor());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
