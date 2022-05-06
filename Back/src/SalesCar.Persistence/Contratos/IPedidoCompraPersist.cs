using System;
using System.Threading.Tasks;
using SalesCar.Domain;

namespace SalesCar.Persistence.Contratos
{
    public interface IPedidoCompraPersist
    {
         Task<PedidoCompra[]> GetAllPedCompByDataAsync(DateTime? data);
         Task<PedidoCompra[]> GetAllPedCompAsync();
         Task<PedidoCompra> GetPedCompByIdAsync(int pedcompId);                  
    }
}