using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Plugins.DataStore.SQL
{
    public class CronosContext : DbContext
    {
        public CronosContext(DbContextOptions<CronosContext> options) : base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category() { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category() { CategoryId = 3, Name = "Meat", Description = "Meat" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Description = "Chá gelado", Quantity = 100, Price = 3.99 },
                new Product() { ProductId = 2, CategoryId = 1, Name = "Canadian", Description = "Canadense", Quantity = 200, Price = 4.99 },
                new Product() { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Description = "Pão Integral", Quantity = 300, Price = 5.99 },
                new Product() { ProductId = 4, CategoryId = 2, Name = "White Bread", Description = "Pão", Quantity = 300, Price = 6.99 }
            );
        }
    }
}