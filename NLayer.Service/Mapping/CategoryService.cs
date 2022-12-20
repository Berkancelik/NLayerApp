using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using NLayer.Service.Service;

namespace NLayer.Service.Mapping
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> reposityory, IUnitOfWork unitOfWork, ICategoryRepository categoryRepositorye, IMapper mapper) : base(reposityory, unitOfWork)
        {
            _categoryRepository = categoryRepositorye;
            _mapper = mapper;
        }



        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryid)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductAsync(categoryid);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
