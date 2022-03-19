using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            // Add some default categories

            categories = new List<Category>()
            {
                new Category() { CategoryId = 1, Name = "Beverage", Description = "Beverage"},
                new Category() { CategoryId = 2, Name = "Bakery", Description = "Bakery"},
                new Category() { CategoryId = 3, Name = "Meat", Description = "Meat"}
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
                category.CategoryId = 1;

            categories?.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = GetCategoryById(categoryId);

            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories.First(x => x.CategoryId == categoryId);
        }
    }
}