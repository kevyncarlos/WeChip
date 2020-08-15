using Microsoft.EntityFrameworkCore;
using WeChip.Data.Mappings;
using WeChip.Domain.Entities;

namespace WeChip.Data
{
    public class WeChipContext : DbContext
    {
        public WeChipContext(DbContextOptions<WeChipContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
        }
    }
}
