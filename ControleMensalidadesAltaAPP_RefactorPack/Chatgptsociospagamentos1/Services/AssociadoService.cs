using System.Collections.Generic;
using System.Threading.Tasks;
using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace Chatgptsociospagamentos.Services
{
    public class AssociadoService : IAssociadoService
    {
        private readonly AppDbContext _context;
        public AssociadoService(AppDbContext context) => _context = context;

        public async Task<List<AssociadoModel>> ListarAsync() => await _context.Associados.AsNoTracking().ToListAsync();
        public async Task<AssociadoModel> ObterAsync(int id) => await _context.Associados.FindAsync(id);
        public async Task CriarAsync(AssociadoModel model) { _context.Associados.Add(model); await _context.SaveChangesAsync(); }
        public async Task AtualizarAsync(AssociadoModel model) { _context.Associados.Update(model); await _context.SaveChangesAsync(); }
        public async Task RemoverAsync(int id) { var a = await _context.Associados.FindAsync(id); if (a!=null){ _context.Associados.Remove(a); await _context.SaveChangesAsync(); } }
    }
}
