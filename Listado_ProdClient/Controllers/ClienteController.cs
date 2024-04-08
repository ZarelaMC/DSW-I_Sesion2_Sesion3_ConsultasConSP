using Microsoft.AspNetCore.Mvc;

using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Listado_ProdClient.Models;

namespace Listado_ProdClient.Controllers
{
    public class ClienteController : Controller
    {
        public readonly IConfiguration Configuration;

        public ClienteController(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }
        
        public List<Cliente> listadoClientes()
        {
            List<Cliente> aCliente = new List<Cliente>();

            SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);

            cn.Open();

            SqlCommand cmd = new SqlCommand("SP_LISTAR_CLIENTES", cn);

            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                aCliente.Add(new Cliente()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    rso_cli = dr[1].ToString(),
                    dir_cli = dr[2].ToString(),
                    tlf_cli = dr[3].ToString(),
                    ruc_cli = dr[4].ToString(),
                    nom_dis = dr[5].ToString(),
                    fec_reg = DateTime.Parse(dr[6].ToString()),
                    con_cli = dr[7].ToString()
                });
            }
            cn.Close();

            return aCliente;
        }
        public IActionResult listaClientes()
        {
            return View(listadoClientes());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
