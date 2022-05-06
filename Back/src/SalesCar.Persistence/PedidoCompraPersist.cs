using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesCar.Domain;
using SalesCar.Domain.Contextos;
using SalesCar.Persistence.Contratos;


namespace SalesCar.Persistence
{
    public class PedidoCompraPersist : IPedidoCompraPersist
    {
        private readonly SalesCarContext _context;
        public PedidoCompraPersist(SalesCarContext context)
        {
            _context = context;
        }

        public async Task<PedidoCompra[]> GetAllPedCompAsync()
        {
            IQueryable<PedidoCompra> query = _context.PedidoCompra;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<PedidoCompra[]> GetAllPedCompByDataAsync(DateTime? data)
        {
            IQueryable<PedidoCompra> query = _context.PedidoCompra;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => c.Data.Equals(data.ToString()));

            return await query.ToArrayAsync();
        }

        public async Task<PedidoCompra> GetPedCompByIdAsync(int pedcompId)
        {
            IQueryable<PedidoCompra> query = _context.PedidoCompra;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => c.Id == pedcompId);

            return await query.FirstOrDefaultAsync();
        }
    }
}