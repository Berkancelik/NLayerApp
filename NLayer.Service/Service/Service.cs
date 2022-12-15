using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using NLayer.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayer.Service.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _reposityory;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> reposityory, IUnitOfWork unitOfWork)
        {
            _reposityory = reposityory;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _reposityory.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _reposityory.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _reposityory.AnyAsync(expression);
        }

      
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _reposityory.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasProduct =  await _reposityory.GetByIdAsync(id);
            if (hasProduct ==null)
            {
                throw new NotFoundException($"{typeof(T).Name} {id} not found");
            }
            return hasProduct;
        }

        public async Task RemoveAsync(T entity)
        {
            _reposityory.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _reposityory.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _reposityory.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _reposityory.Where(expression);
        }

    
    }
}
