using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> reposityory, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(reposityory, unitOfWork)
        {
            _mapper = mapper;
            _repository = productRepository;
        }



        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            var product = await _repository.GetProductWithCategory();
            var prodcutsDto= _mapper.Map<List<ProductWithCategoryDto>>(product);
            return  CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, prodcutsDto);
        }

       
    }
}
