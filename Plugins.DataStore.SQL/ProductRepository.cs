using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly CronosContext cronosContext;

        public ProductRepository(CronosContext cronosContext)
        {
            this.cronosContext = cronosContext;
        }

        public void AddProduct(Product product)
        {
            cronosContext.Products.Add(product);
            cronosContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = cronosContext.Products.Find(productId);
            if (product == null)
                return;

            cronosContext.Products.Remove(product);
            cronosContext.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return cronosContext.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return cronosContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return cronosContext.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = cronosContext.Products.Find(product.ProductId);
            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            cronosContext.SaveChanges();
        }
    }
}
