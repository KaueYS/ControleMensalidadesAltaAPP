using Chatgptsociospagamentos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chatgptsociospagamentos.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<AssociadoModel> Associados { get; set; }
        public DbSet<PagamentoModel> Pagamentos { get; set; }
        public DbSet<DocumentoModel> Documentos { get; set; }
    }
}
