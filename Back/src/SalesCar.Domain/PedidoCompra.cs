using System;

namespace SalesCar.Domain
{
    public class PedidoCompra
    {
        public int Id { get; set; }
        public int CarroId { get; set; }        
        public Carro Carro { get; set; }        
        public DateTime? Data { get; set; }
        public double PrecoTotal { get; set; }        
        public int Qt { get; set; }
        public int PrecoCompra { get; set; }
        public string Empresa { get; set; }
    
    }
}