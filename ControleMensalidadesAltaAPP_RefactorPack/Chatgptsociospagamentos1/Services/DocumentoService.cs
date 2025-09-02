using System.Collections.Generic;
using System.Threading.Tasks;
using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace Chatgptsociospagamentos.Services
{
    public class DocumentoService : IDocumentoService
    {
        private readonly AppDbContext _context;
        public DocumentoService(AppDbContext context) => _context = context;

        public async Task<List<DocumentoModel>> ListarAsync() => await _context.Documentos.AsNoTracking().ToListAsync();
        public async Task<DocumentoModel> ObterAsync(int id) => await _context.Documentos.FindAsync(id);
        public async Task CriarAsync(DocumentoModel model) { _context.Documentos.Add(model); await _context.SaveChangesAsync(); }
        public async Task RemoverAsync(int id) { var d = await _context.Documentos.FindAsync(id); if (d!=null){ _context.Documentos.Remove(d); await _context.SaveChangesAsync(); } }
    }
}
