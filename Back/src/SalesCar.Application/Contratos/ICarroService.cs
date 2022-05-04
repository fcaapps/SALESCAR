using System.Threading.Tasks;
using SalesCar.Application.Dtos;
using SalesCar.Domain;

namespace SalesCar.Application
{
    public interface ICarroService
    {
        Task<CarroDto> AddCarro(CarroDto model);
        Task<CarroDto> UpdateCarro(int carroId, CarroDto model);
        Task<bool> DeleteCarro(int carroId);
        Task<CarroDto[]> GetAllCarrosAsync();
        Task<CarroDto[]> GetAllCarrosByDescricaoAsync(string descricao);
        Task<CarroDto> GetCarrosByIdAsync(int carroId);
    }
}