using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CronosContext cronosContext;
        public CategoryRepository(CronosContext cronosContext)
        {
            this.cronosContext = cronosContext;
        }
        public void AddCategory(Category category)
        {
            cronosContext.Categories.Add(category);
            cronosContext.SaveChanges();

        }

        public void DeleteCategory(int categoryId)
        {
            var category = cronosContext.Categories.Find(categoryId);
            if (category == null)
                return;

            cronosContext.Categories.Remove(category);
            cronosContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return cronosContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return cronosContext.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var cat = cronosContext.Categories.Find(category.CategoryId);
            cat.Name = category.Name;
            cat.Description = category.Description;
            cronosContext.SaveChanges();
        }
    }
}
