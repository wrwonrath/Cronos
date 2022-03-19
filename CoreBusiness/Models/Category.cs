using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public List<Product> Products { get; set; }
    }
}