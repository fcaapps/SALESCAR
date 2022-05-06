using System;
using System.Threading.Tasks;
using AutoMapper;
using SalesCar.Application.Dtos;
using SalesCar.Domain;
using SalesCar.Persistence.Contratos;

namespace SalesCar.Application
{
    public class PedidoCompraService : IPedidoCompraService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPedidoCompraPersist _pedidoCompraPersist;
        private readonly IMapper _mapper;

        public PedidoCompraService(IGeralPersist geralPersist,
                            IPedidoCompraPersist pedidoCompraPersist,        
                            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _pedidoCompraPersist = pedidoCompraPersist;            
            _mapper = mapper;
            

        }
    public async Task<PedidoCompraDto> AddPedidoCompra(PedidoCompraDto model)
    {
        try
        {
            
            var pedidocompra = _mapper.Map<PedidoCompra>(model);    

            _geralPersist.Add<PedidoCompra>(pedidocompra);

            if (await _geralPersist.SaveChangesAsync())
            {
                var pedidoCompraRetorno = await _pedidoCompraPersist.GetPedCompByIdAsync(pedidocompra.Id);

                return _mapper.Map<PedidoCompraDto>(pedidoCompraRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<PedidoCompraDto> UpdatePedidoCompra(int pedidocompraId, PedidoCompraDto model)
    {
        
        try
        {
            var pedidocompra = await _pedidoCompraPersist.GetPedCompByIdAsync(pedidocompraId);

            if (pedidocompra == null) return null;

            model.Id = pedidocompra.Id;

            _mapper.Map(model, pedidocompra);

            _geralPersist.Update<PedidoCompra>(pedidocompra);

            if (await _geralPersist.SaveChangesAsync())
            {
                var pedidoCompraRetorno = await _pedidoCompraPersist.GetPedCompByIdAsync(pedidocompra.Id);

                return _mapper.Map<PedidoCompraDto>(pedidoCompraRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeletePedidoCompra(int pedidocompraId)
    {
        try
        {
            var pedidocompra = await _pedidoCompraPersist.GetPedCompByIdAsync(pedidocompraId);

            if (pedidocompra == null) throw new Exception("pedidocompra não encontrado.");

            _geralPersist.Delete<PedidoCompra>(pedidocompra);

            return await _geralPersist.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoCompraDto[]> GetAllPedCompAsync()
    {
        try
        {
            var pedidocompras = await _pedidoCompraPersist.GetAllPedCompAsync();

            if (pedidocompras == null) return null;

             var resultado = _mapper.Map<PedidoCompraDto[]>(pedidocompras);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoCompraDto[]> GetAllPedCompByDataAsync(DateTime? data)
    {
        try
        {
            var pedidocompras = await _pedidoCompraPersist.GetAllPedCompByDataAsync(data);

            if (pedidocompras == null) return null;

            var resultado = _mapper.Map<PedidoCompraDto[]>(pedidocompras);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoCompraDto> GetPedCompByIdAsync(int pedidocompraId)
    {
        try
        {
            var pedidocompra = await _pedidoCompraPersist.GetPedCompByIdAsync(pedidocompraId);

            if (pedidocompra == null) return null;

            var resultado = _mapper.Map<PedidoCompraDto>(pedidocompra);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

        
    }
}