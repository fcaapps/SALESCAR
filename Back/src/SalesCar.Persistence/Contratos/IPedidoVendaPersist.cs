using System;
using System.Threading.Tasks;
using SalesCar.Domain;

namespace SalesCar.Persistence.Contratos
{
    public interface IPedidoVendaPersist
    {
         Task<PedidoVenda[]> GetAllPedVendaByDataAsync(DateTime? data);
         Task<PedidoVenda[]> GetAllPedVendaAsync();
         Task<PedidoVenda> GetPedVendaByIdAsync(int pedvendaId);                  
    }
}