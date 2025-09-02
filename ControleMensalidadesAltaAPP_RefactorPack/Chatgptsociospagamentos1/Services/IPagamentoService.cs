using System.Collections.Generic;
using System.Threading.Tasks;
using Chatgptsociospagamentos.Models;

namespace Chatgptsociospagamentos.Services
{
    public interface IPagamentoService
    {
        Task<List<PagamentoModel>> ListarAsync();
        Task<PagamentoModel> ObterAsync(int id);
        Task RegistrarAsync(PagamentoModel pagamento);
        Task UpdateAsync(PagamentoModel pagamento);
        Task RemoverAsync(int id);
    }
}
