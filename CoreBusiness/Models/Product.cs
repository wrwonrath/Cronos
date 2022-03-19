using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Informe a categoria do produto")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Informe a quantidade maior ou igual a zero")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Informe o preço maior ou igual a zero")]
        public double Price { get; set; }

        public Category Category { get; set; }
    }
}