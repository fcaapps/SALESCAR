using System.ComponentModel.DataAnnotations;

namespace SalesCar.Application.Dtos
{
    public class CarroDto
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }
        public string Cor { get; set; } 
        public string AnoModelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string Marca { get; set; }   
        public string Empresa { get; set; }
        public string Modelo { get; set; }
        public double MargemIdeal { get; set; }
        public double MargemMinima { get; set; }
    }
}