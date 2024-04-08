using System.ComponentModel;

namespace Listado_ProdClient.Models
{
    public class Cliente
    {
        [DisplayName("CÓDIGO")]
        public int ide_cli { get; set; }

        [DisplayName("RAZÓN SOCIAL")]
        public string rso_cli { get; set; }

        [DisplayName("DIRECCIÓN")]
        public string dir_cli { get; set; }

        [DisplayName("TELÉFONO")]
        public string tlf_cli { get; set;}

        [DisplayName("RUC")]
        public string ruc_cli { get; set; }

        [DisplayName("DISTRITO")]
        public string nom_dis {  get; set; }

        [DisplayName("FECHA DE REGISTRO")]
        public DateTime fec_reg { get;set; }

        [DisplayName("REPRESENTANTE")]
        public string con_cli { get; set; }
    }
}
