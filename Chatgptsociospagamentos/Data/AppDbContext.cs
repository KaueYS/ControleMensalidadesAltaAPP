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
        public DbSet<Associado> Associados { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
