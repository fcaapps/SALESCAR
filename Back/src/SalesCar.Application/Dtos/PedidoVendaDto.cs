namespace SalesCar.Application.Dtos
{
    public class PedidoVendaDto    
    {
        public int Id { get; set; }
        public int CarroId { get; set; }        
        public string Data { get; set; }
        public double PrecoTotal { get; set; }                
        public int Qt { get; set; }
        public int PrecoVenda { get; set; }
        public string Empresa { get; set; }
    
    }
}