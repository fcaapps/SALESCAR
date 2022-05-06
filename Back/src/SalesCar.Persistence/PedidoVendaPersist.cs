using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesCar.Domain;
using SalesCar.Domain.Contextos;
using SalesCar.Persistence.Contratos;

namespace SalesCar.Persistence
{
    public class PedidoVendaPersist : IPedidoVendaPersist
    {
 	public SalesCarContext _context { get; set; }
        public PedidoVendaPersist(SalesCarContext context)
        {
            _context = context;

        }
        public async Task<PedidoVenda[]> GetAllPedVendaAsync()
        {
            IQueryable<PedidoVenda> query = _context.PedidoVenda;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<PedidoVenda[]> GetAllPedVendaByDataAsync(DateTime? data)
        {
            IQueryable<PedidoVenda> query = _context.PedidoVenda;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => c.Data.Equals(data.ToString()));

            return await query.ToArrayAsync();
        }

        public async Task<PedidoVenda> GetPedVendaByIdAsync(int pedcompId)
        {
            IQueryable<PedidoVenda> query = _context.PedidoVenda;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => c.Id == pedcompId);

            return await query.FirstOrDefaultAsync();
        }
    }
}