using Microsoft.EntityFrameworkCore;
using SalesCar.Domain;

namespace SalesCar.Domain.Contextos
{
    public class SalesCarContext : DbContext
    {
        public SalesCarContext(DbContextOptions<SalesCarContext> options) : base(options) {}
        public DbSet<Carro> Carros { get; set; }
        public DbSet<TabelaPreco> TabelaPreco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TabelaPreco>()
                .HasKey(TP => new {TP.CarroId, TP.Id});
        }
    }
}