using System;
using System.Threading.Tasks;
using SalesCar.Application.Dtos;
using SalesCar.Domain;

namespace SalesCar.Application
{
    public interface IPedidoCompraService
    {
        Task<PedidoCompraDto> AddPedidoCompra(PedidoCompraDto model);
        Task<PedidoCompraDto> UpdatePedidoCompra(int PedidoCompraId, PedidoCompraDto model);
        Task<bool> DeletePedidoCompra(int PedidoCompraId);
        Task<PedidoCompraDto[]> GetAllPedCompAsync();
        Task<PedidoCompraDto[]> GetAllPedCompByDataAsync(DateTime? Data);
        Task<PedidoCompraDto> GetPedCompByIdAsync(int PedidoCompraId);
    }
}