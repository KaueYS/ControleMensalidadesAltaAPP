using Chatgptsociospagamentos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chatgptsociospagamentos.Models
{
    public class Associado
    {
        public int AssociadoId { get; set; }

        [Display(Name = "Nome Completo")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "RG ou CPF")]
        public string? Documento { get; set; } = string.Empty;

        [EmailAddress]
      
        public string? Email { get; set; } = string.Empty;
       
        public string? Telefone { get; set; } = string.Empty;

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; } = string.Empty;




        [Display(Name = "Data Aniversário")]
        public DateTime DataAniversario { get; set; }

       
        public CategoriaEnum Categoria { get; set; }

        [Display(Name = "Equipamento Próprio")]
        public bool Equipamento { get; set; }


        [Display(Name = "Necessidades Especiais")]
        public bool Necessidade {  get; set; } 


        public bool Ativo {  get; set; }

    }
}
