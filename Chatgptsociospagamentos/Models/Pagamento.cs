using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chatgptsociospagamentos.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        [Display(Name = "Nome do sócio")]
        public int AssociadoId { get; set; }
        public double Valor { get; set; }
        
        public DateTime DataPagamento { get; set; }
        [Display(Name = "QTD dias pagos")]
        public double ParcelasPagas { get; set; }
        public Associado? Associado { get; set; }

        [Display(Name = "Pago até o dia")]
        public DateTime MesAdimplente { get; set; }
    }
}
