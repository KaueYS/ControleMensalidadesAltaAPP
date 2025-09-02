using System;
namespace Chatgptsociospagamentos.ViewModels
{
    public class PagamentoVm
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public string SocioNome { get; set; }
        public DateTime DataPagamento { get; set; }
        public int DiasAdimplencia { get; set; }
        public decimal Valor { get; set; }
    }
}
