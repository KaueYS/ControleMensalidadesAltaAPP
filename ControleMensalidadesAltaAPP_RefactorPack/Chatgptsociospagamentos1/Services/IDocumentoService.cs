using System.Collections.Generic;
using System.Threading.Tasks;
using Chatgptsociospagamentos.Models;

namespace Chatgptsociospagamentos.Services
{
    public interface IDocumentoService
    {
        Task<List<DocumentoModel>> ListarAsync();
        Task<DocumentoModel> ObterAsync(int id);
        Task CriarAsync(DocumentoModel model);
        Task RemoverAsync(int id);
    }
}
