using System;
using System.Threading.Tasks;
using AutoMapper;
using SalesCar.Application.Dtos;
using SalesCar.Domain;
using SalesCar.Persistence.Contratos;

namespace SalesCar.Application
{
    public class PedidoVendaService : IPedidoVendaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPedidoVendaPersist _pedidoVendaPersist;
        private readonly IMapper _mapper;

        public PedidoVendaService(IGeralPersist geralPersist,
                            IPedidoVendaPersist carroPersist,        
                            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _pedidoVendaPersist = carroPersist;            
            _mapper = mapper;
            

        }
    public async Task<PedidoVendaDto> AddPedidoVenda(PedidoVendaDto model)
    {
        try
        {
            
            var pedidovenda = _mapper.Map<Carro>(model);    

            _geralPersist.Add<Carro>(pedidovenda);

            if (await _geralPersist.SaveChangesAsync())
            {
                var pedidovendaRetorno = await _pedidoVendaPersist.GetPedVendaByIdAsync(pedidovenda.Id);

                return _mapper.Map<PedidoVendaDto>(pedidovendaRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<PedidoVendaDto> UpdatePedidoVenda(int pedidovendaId, PedidoVendaDto model)
    {
        
        try
        {
            var pedidovenda = await _pedidoVendaPersist.GetPedVendaByIdAsync(pedidovendaId);

            if (pedidovenda == null) return null;

            model.Id = pedidovenda.Id;

            _mapper.Map(model, pedidovenda);

            _geralPersist.Update<PedidoVenda>(pedidovenda);

            if (await _geralPersist.SaveChangesAsync())
            {
                var pedidovendaRetorno = await _pedidoVendaPersist.GetPedVendaByIdAsync(pedidovenda.Id);

                return _mapper.Map<PedidoVendaDto>(pedidovendaRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeletePedidoVenda(int pedidovendaId)
    {
        try
        {
            var pedidovenda = await _pedidoVendaPersist.GetPedVendaByIdAsync(pedidovendaId);

            if (pedidovenda == null) throw new Exception("pedidovenda não encontrado.");

            _geralPersist.Delete<PedidoVenda>(pedidovenda);

            return await _geralPersist.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoVendaDto[]> GetAllPedVendaAsync()
    {
        try
        {
            var pedidovendas = await _pedidoVendaPersist.GetAllPedVendaAsync();

            if (pedidovendas == null) return null;

             var resultado = _mapper.Map<PedidoVendaDto[]>(pedidovendas);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoVendaDto[]> GetAllPedVendaByDataAsync(DateTime? data)
    {
        try
        {
            var pedidovendas = await _pedidoVendaPersist.GetAllPedVendaByDataAsync(data);

            if (pedidovendas == null) return null;

            var resultado = _mapper.Map<PedidoVendaDto[]>(pedidovendas);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoVendaDto> GetPedVendaByIdAsync(int pedidovendaId)
    {
        try
        {
            var pedidovenda = await _pedidoVendaPersist.GetPedVendaByIdAsync(pedidovendaId);

            if (pedidovenda == null) return null;

            var resultado = _mapper.Map<PedidoVendaDto>(pedidovenda);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}
}