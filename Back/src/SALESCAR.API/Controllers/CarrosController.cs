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
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarrosController(ICarroService carroService)
        {
            _carroService = carroService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var carros = await _carroService.GetAllCarrosAsync();

                if (carros == null) return NoContent();

                var carrosRetorno = new List<CarroDto>();

                foreach (var carro in carros)
                {
                    carrosRetorno.Add(new CarroDto(){
                        Id = carro.Id,
                        Descricao = carro.Descricao,
                        Cor = carro.Cor,
                        AnoModelo = carro.AnoModelo,
                        AnoFabricacao = carro.AnoFabricacao,
                        Marca = carro.Marca
                    });
                }

                return Ok(carrosRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar carros. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var carros = await _carroService.GetCarrosByIdAsync(id);

                if (carros == null) return NoContent();

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar carros. Erro: {ex.Message}");                
            }
        }
        [HttpGet("{descricao}/descricao")]
        public async Task<IActionResult> GetByDescricao(string descricao)
        {
            try
            {
                var carros = await _carroService.GetAllCarrosByDescricaoAsync(descricao);

                if (carros == null) return NoContent();

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar carros. Erro: {ex.Message}");                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarroDto model) 
        {
           try
            {
                var carros = await _carroService.AddCarro(model);

                if (carros == null) return NoContent();

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar carros. Erro: {ex.Message}");                
            } 
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CarroDto model) 
        {
           try
            {
                var carros = await _carroService.UpdateCarro(id, model);

                if (carros == null) return NoContent();

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar carros. Erro: {ex.Message}");                
            } 
        }

[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _carroService.GetCarrosByIdAsync(id);
                if (evento == null) return NoContent();

                return await _carroService.DeleteCarro(id) ? 
                       Ok(new { message = "Deletado"}) : 
                       BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }

    }
}
