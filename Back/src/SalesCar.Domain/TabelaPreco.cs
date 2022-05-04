using SalesCar.Domain;

namespace SalesCar.Domain
{
    public class TabelaPreco
    {
        public int Id { get; set; }     
        public double Preco { get; set; }      
        public int? CarroId { get; set; }
        public Carro Carro { get; set; }
    }
}