using System.Collections.Generic;
using System.Threading.Tasks;
using Chatgptsociospagamentos.Models;

namespace Chatgptsociospagamentos.Services
{
    public interface IAssociadoService
    {
        Task<List<AssociadoModel>> ListarAsync();
        Task<AssociadoModel> ObterAsync(int id);
        Task CriarAsync(AssociadoModel model);
        Task AtualizarAsync(AssociadoModel model);
        Task RemoverAsync(int id);
    }
}
