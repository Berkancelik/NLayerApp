using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, CategoryId = 1, Name = "Kalem 1", Stock = 25, Price = 100, CreatedDate = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "Kalem 2", Price = 300, Stock = 25, CreatedDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 2, Name = "Kitap 1", Price = 400, Stock = 35, CreatedDate = DateTime.Now });
        }
    }
}
