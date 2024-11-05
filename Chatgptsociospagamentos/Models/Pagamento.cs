using System.ComponentModel.DataAnnotations.Schema;

namespace Chatgptsociospagamentos.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public int AssociadoId { get; set; }
        public double Valor { get; set; }
        [Column("Data Pagamento")]
        public DateTime DataPagamento { get; set; }
      
        public double ParcelasPagas { get; set; }
        public Associado? Associado { get; set; }
        public DateTime MesAdimplente { get; set; }
    }
}
