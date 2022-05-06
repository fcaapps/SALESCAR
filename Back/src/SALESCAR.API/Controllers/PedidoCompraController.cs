using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesCar.Application.Dtos;
using SalesCar.Application;
using SalesCar.Domain.Contextos;

namespace SalesCar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoCompraController : ControllerBase
    {
        private readonly IPedidoCompraService _pedidoCompraService;

        public PedidoCompraController(IPedidoCompraService pedidoCompraService)
        {
            _pedidoCompraService = pedidoCompraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidocompras = await _pedidoCompraService.GetAllPedCompAsync();

                if (pedidocompras == null) return NoContent();

                var pedidocompraRetorno = new List<PedidoCompraDto>();

                foreach (var pedidoCompra in pedidocompras)
                {
                    pedidocompraRetorno.Add(new PedidoCompraDto(){
                        Id = pedidoCompra.Id,
                        CarroId = pedidoCompra.Id,
                        Data = pedidoCompra.Data,
                        PrecoCompra = pedidoCompra.PrecoCompra,
                        Qt = pedidoCompra.Qt,
                        PrecoTotal = pedidoCompra.PrecoTotal,
                        Empresa = pedidoCompra.Empresa
                    });
                }

                return Ok(pedidocompraRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedidocompras = await _pedidoCompraService.GetPedCompByIdAsync(id);

                if (pedidocompras == null) return NoContent();

                return Ok(pedidocompras);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");                
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PedidoCompraDto model) 
        {
           try
            {
                var pedidocompras = await _pedidoCompraService.AddPedidoCompra(model);

                if (pedidocompras == null) return NoContent();

                return Ok(pedidocompras);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar pedido. Erro: {ex.Message}");                
            } 
        }

    }
}
