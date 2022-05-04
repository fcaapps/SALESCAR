using System;
using System.Threading.Tasks;
using SalesCar.Domain;
using SalesCar.Persistence.Contratos;

namespace SalesCar.Application
{
    public class CarroService : ICarroService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ICarroPersist _carroPersist;
        public CarroService(IGeralPersist geralPersist, ICarroPersist carroPersist)
        {
            _carroPersist = carroPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Carro> AddCarro(Carro model)
        {
            try
            {
                _geralPersist.Add<Carro>(model);

                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _carroPersist.GetCarrosByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Carro> UpdateCarro(int carroId, Carro model)
        {
            try
            {
                var carro = await _carroPersist.GetCarrosByIdAsync(carroId);

                if(carro == null) return null;

                model.Id = carro.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _carroPersist.GetCarrosByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCarro(int carroId)
        {
            try
            {
                var carro = await _carroPersist.GetCarrosByIdAsync(carroId);

                if(carro == null) throw new Exception("Carro não encontrado.");

                _geralPersist.Delete<Carro>(carro);

                return await _geralPersist.SaveChangesAsync(); 

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Carro[]> GetAllCarrosAsync()
        {
            try
            {
                var carros = await _carroPersist.GetAllCarrosAsync();

                if (carros == null) return null;

                return carros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Carro[]> GetAllCarrosByDescricaoAsync(string descricao)
        {
            try
            {
                var carros = await _carroPersist.GetAllCarrosByDescricaoAsync(descricao);

                if (carros == null) return null;

                return carros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Carro> GetCarrosByIdAsync(int carroId)
        {
            try
            {
                var carros = await _carroPersist.GetCarrosByIdAsync(carroId);

                if (carros == null) return null;

                return carros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}