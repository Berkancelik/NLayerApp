using NLayer.Core.Entities;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryBtIdWithProductAsync(int categoryid);
    }
}
