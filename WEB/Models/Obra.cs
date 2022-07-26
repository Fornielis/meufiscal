using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe tipo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe agente campo")]
        public string Fiscal { get; set; }

        public string Risco { get; set; }

        public string Estatus { get; set; }
        public string Urgente { get; set; }

    }
}
