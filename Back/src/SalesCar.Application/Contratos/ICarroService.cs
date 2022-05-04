using System.Threading.Tasks;
using SalesCar.Domain;

namespace SalesCar.Application
{
    public interface ICarroService
    {
        Task<Carro> AddCarro(Carro model);
        Task<Carro> UpdateCarro(int carroId, Carro model);
        Task<bool> DeleteCarro(int carroId);
        Task<Carro[]> GetAllCarrosAsync();
        Task<Carro[]> GetAllCarrosByDescricaoAsync(string descricao);
        Task<Carro> GetCarrosByIdAsync(int carroId);
    }
}