namespace SalesCar.Application.Dtos
{
    public class PedidoCompraDto
    {
        public int Id { get; set; }
        public int CarroId { get; set; }                
        public string Data { get; set; }
        public double PrecoTotal { get; set; }        
        public int Qt { get; set; }
        public int PrecoCompra { get; set; }
        public string Empresa { get; set; }
    }
}