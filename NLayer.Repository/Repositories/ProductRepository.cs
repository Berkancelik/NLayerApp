using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context, DbSet<Product> dbSet) : base(context, dbSet)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            //Eager Loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        Task<CustomResponseDto<List<ProductWithCategoryDto>>> IProductRepository.GetProductWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
