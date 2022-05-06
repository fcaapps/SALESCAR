using AutoMapper;
using SalesCar.Application.Dtos;
using SalesCar.Domain;

namespace SalesCar.Application.Helpers
{
    public class SalesCarProfile : Profile
    {
        public SalesCarProfile()
        {
            CreateMap<Carro, CarroDto>().ReverseMap();
            CreateMap<PedidoCompra, PedidoCompraDto>().ReverseMap();
            CreateMap<PedidoVenda, PedidoVenda>().ReverseMap();
        }
    }
}