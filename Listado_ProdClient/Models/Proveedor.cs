using System.ComponentModel;

namespace Listado_ProdClient.Models
{
    public class Proveedor
    {
        [DisplayName("CÓDIGO")]
        public int ide_prv { get; set; }

        [DisplayName("RAZÓN SOCIAL")]
        public string raz_soc_prv { get; set; }

        [DisplayName("DIRECCIÓN")]
        public string dir_prv { get; set; }

        [DisplayName("TELÉFONO")]
        public string tel_prv { get; set; }

        [DisplayName("DISTRITO")]
        public string nom_dis { get; set;}

        [DisplayName("REPRESENTANTE")]
        public string rep_ven { get; set;}
    }
}
