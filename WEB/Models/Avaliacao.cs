using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }
        public int ObraId { get; set; }

        [Required(ErrorMessage = "Informe se foi corrigido no ato")]
        public string CorrigidoAto { get; set; }

        [Required(ErrorMessage = "Informe se há necessidade de SPR")]
        public string SPR { get; set; }

        [Required(ErrorMessage = "Informe se há risco")]
        public string Risco { get; set; }

        [Required(ErrorMessage = "Informe Descrição")]
        public string Descricao { get; set; }
    }
}
