using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chatgptsociospagamentos.Models
{
    public class Associado
    {
        public int AssociadoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Documento { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;


        public DateTime DataAniversario { get; set; } 

       
        DateTime DataAssociacao { get; set; }
        public bool Ativo {  get; set; }
    }
}
