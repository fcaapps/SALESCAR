using System.Threading.Tasks;
using SalesCar.Domain;

namespace SalesCar.Persistence.Contratos
{
    public interface ICarroPersist
    {
         Task<Carro[]> GetAllCarrosByDescricaoAsync(string descricao);
         Task<Carro[]> GetAllCarrosAsync();
         Task<Carro> GetCarrosByIdAsync(int carroId);
         
    }
}