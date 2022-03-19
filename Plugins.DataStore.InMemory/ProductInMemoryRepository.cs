using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();

        public ProductInMemoryRepository()
        {
            // Add some default products

            products = new List<Product>()
            {
                new Product() { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Description = "Chá gelado", Quantity = 100, Price = 3.99},
                new Product() { ProductId = 2, CategoryId = 1, Name = "Canadian", Description = "Canadense", Quantity = 200, Price = 4.99},
                new Product() { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Description = "Pão Integral", Quantity = 300, Price = 5.99},
                new Product() { ProductId = 4, CategoryId = 2, Name = "White Bread", Description = "Pão", Quantity = 300, Price = 6.99}
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
                product.ProductId = 1;

            products?.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int productId)
        {
            return products.First(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}