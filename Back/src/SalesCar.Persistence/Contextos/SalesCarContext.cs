using Microsoft.EntityFrameworkCore;
using SalesCar.Domain;

namespace SalesCar.Domain.Contextos
{
    public class SalesCarContext : DbContext
    {
        public SalesCarContext(DbContextOptions<SalesCarContext> options) : base(options) {}
        public DbSet<Carro> Carros { get; set; }
        public DbSet<PedidoCompra> PedidoCompra { get; set; }
        public DbSet<PedidoVenda> PedidoVenda { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //     modelBuilder.Entity<TabelaPreco>()
        //         .HasKey(TP => new {TP.CarroId, TP.Id});
        //     modelBuilder.Entity<ItensCompra>()
        //         .HasKey(IC => new {IC.PedidoCompraId, IC.Id});
        //     modelBuilder.Entity<ItensVenda>()
        //         .HasKey(IV => new {IV.PedidoVendaId, IV.Id});
        // }
    }
}