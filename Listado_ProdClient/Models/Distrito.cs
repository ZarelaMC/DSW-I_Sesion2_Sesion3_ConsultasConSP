using System.ComponentModel;

namespace Listado_ProdClient.Models
{
    public class Distrito
    {
        [DisplayName("CÓDIGO")]
        public int ide_dis { get; set; }

        [DisplayName("DISTRITO")]
        public string nom_dis { get; set; }
    }
}
