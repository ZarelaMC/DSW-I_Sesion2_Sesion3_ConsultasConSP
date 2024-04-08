using System.ComponentModel;

namespace Listado_ProdClient.Models
{
    public class Vendedor
    {
        [DisplayName("CÓDIGO")]
        public int id_ven { get; set; }

        [DisplayName("VENDEDOR")]
        public string ven { get; set; }

        [DisplayName("SUELDO")]
        public Double sue_ven { get; set; }

        [DisplayName("FECHA DE INGRESO")]
        public DateTime fec_ing { get; set; }

        [DisplayName("DISTRITO")]
        public string nom_dis { get; set; }
    }
}
