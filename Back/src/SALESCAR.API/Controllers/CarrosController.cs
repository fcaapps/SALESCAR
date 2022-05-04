using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesCar.Application;
using SalesCar.Domain;
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

                if (carros == null) return NotFound("Nenhum carro encontrado.");

                return Ok(carros);
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

                if (carros == null) return NotFound("Nenhum carro encontrado pelo id informado.");

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

                if (carros == null) return NotFound("Nenhum carro encontrado pela descrição informada.");

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar carros. Erro: {ex.Message}");                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Carro model) 
        {
           try
            {
                var carros = await _carroService.AddCarro(model);

                if (carros == null) return BadRequest("Erro ao tentar adicionar carro.");

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar carros. Erro: {ex.Message}");                
            } 
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Carro model) 
        {
           try
            {
                var carros = await _carroService.UpdateCarro(id, model);

                if (carros == null) return BadRequest("Erro ao tentar adicionar carro.");

                return Ok(carros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar carros. Erro: {ex.Message}");                
            } 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Carro model) 
        {
           try
            {
                return await _carroService.DeleteCarro(id) ? 
                       Ok("Deletado") : 
                       BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar carros. Erro: {ex.Message}");                
            } 
        }
    }
}
