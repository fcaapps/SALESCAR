using System;
using System.Threading.Tasks;
using SalesCar.Application.Dtos;
using SalesCar.Domain;

namespace SalesCar.Application
{
    public interface IPedidoVendaService
    {
        Task<PedidoVendaDto> AddPedidoVenda(PedidoVendaDto model);
        Task<PedidoVendaDto> UpdatePedidoVenda(int PedidoVendaId, PedidoVendaDto model);
        Task<bool> DeletePedidoVenda(int PedidoVendaId);
        Task<PedidoVendaDto[]> GetAllPedVendaAsync();
        Task<PedidoVendaDto[]> GetAllPedVendaByDataAsync(DateTime? data);
        Task<PedidoVendaDto> GetPedVendaByIdAsync(int PedidoVendaId);
    }
}