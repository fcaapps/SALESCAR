using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesCar.Domain;
using SalesCar.Domain.Contextos;
using SalesCar.Persistence.Contratos;

namespace SalesCar.Persistence
{
    //GERAL
    public class SalesCarCarroPersistence : ICarroPersist
    {
        private readonly SalesCarContext _context;

        public SalesCarCarroPersistence(SalesCarContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public async Task<Carro[]> GetAllCarrosAsync()
        {
            IQueryable<Carro> query = _context.Carros;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Carro[]> GetAllCarrosByDescricaoAsync(string descricao)
        {
            IQueryable<Carro> query = _context.Carros;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => c.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<Carro> GetCarrosByIdAsync(int carroId)
        {
            IQueryable<Carro> query = _context.Carros;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => c.Id == carroId);

            return await query.FirstOrDefaultAsync();

        }

    }
}