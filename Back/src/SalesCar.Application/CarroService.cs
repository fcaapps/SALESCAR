using System;
using System.Threading.Tasks;
using AutoMapper;
using SalesCar.Application.Dtos;
using SalesCar.Domain;
using SalesCar.Persistence.Contratos;

namespace SalesCar.Application
{
    public class CarroService : ICarroService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ICarroPersist _carroPersist;
        private readonly IMapper _mapper;

        public CarroService(IGeralPersist geralPersist,
                            ICarroPersist carroPersist,        
                            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _carroPersist = carroPersist;            
            _mapper = mapper;
            

        }
    public async Task<CarroDto> AddCarro(CarroDto model)
    {
        try
        {

            var carro = _mapper.Map<Carro>(model);    

            _geralPersist.Add<Carro>(carro);

            if (await _geralPersist.SaveChangesAsync())
            {
                var carroRetorno = await _carroPersist.GetCarrosByIdAsync(carro.Id);

                return _mapper.Map<CarroDto>(carroRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<CarroDto> UpdateCarro(int carroId, CarroDto model)
    {
        
        try
        {
            var carro = await _carroPersist.GetCarrosByIdAsync(carroId);

            if (carro == null) return null;

            model.Id = carro.Id;

            _mapper.Map(model, carro);

            _geralPersist.Update<Carro>(carro);

            if (await _geralPersist.SaveChangesAsync())
            {
                var carroRetorno = await _carroPersist.GetCarrosByIdAsync(carro.Id);

                return _mapper.Map<CarroDto>(carroRetorno);
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

            if (carro == null) throw new Exception("Carro não encontrado.");

            _geralPersist.Delete<Carro>(carro);

            return await _geralPersist.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<CarroDto[]> GetAllCarrosAsync()
    {
        try
        {
            var carros = await _carroPersist.GetAllCarrosAsync();

            if (carros == null) return null;

             var resultado = _mapper.Map<CarroDto[]>(carros);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<CarroDto[]> GetAllCarrosByDescricaoAsync(string descricao)
    {
        try
        {
            var carros = await _carroPersist.GetAllCarrosByDescricaoAsync(descricao);

            if (carros == null) return null;

            var resultado = _mapper.Map<CarroDto[]>(carros);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<CarroDto> GetCarrosByIdAsync(int carroId)
    {
        try
        {
            var carro = await _carroPersist.GetCarrosByIdAsync(carroId);

            if (carro == null) return null;

            var resultado = _mapper.Map<CarroDto>(carro);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}
}