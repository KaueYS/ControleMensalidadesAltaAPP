using System.Collections.Generic;
using System.Threading.Tasks;
using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace Chatgptsociospagamentos.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly AppDbContext _context;
        public PagamentoService(AppDbContext context) => _context = context;

        public async Task<List<PagamentoModel>> ListarAsync() => await _context.Pagamentos.Include(p=>p.Socio).AsNoTracking().ToListAsync();
        public async Task<PagamentoModel> ObterAsync(int id) => await _context.Pagamentos.Include(p=>p.Socio).FirstOrDefaultAsync(p=>p.Id==id);
        public async Task RegistrarAsync(PagamentoModel pagamento) { _context.Pagamentos.Add(pagamento); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(PagamentoModel pagamento) { _context.Pagamentos.Update(pagamento); await _context.SaveChangesAsync(); }
        public async Task RemoverAsync(int id) { var p = await _context.Pagamentos.FindAsync(id); if (p!=null){ _context.Pagamentos.Remove(p); await _context.SaveChangesAsync(); } }
    }
}
