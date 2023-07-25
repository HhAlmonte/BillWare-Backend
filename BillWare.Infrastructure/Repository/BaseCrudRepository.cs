using AutoMapper;
using BillWare.Application.Shared;
using BillWare.Application.Shared.Entities;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Repository
{
    public class BaseCrudRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IBillWareDbContext _dbContext;

        public BaseCrudRepository(IBillWareDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.GetDbSet<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Get(id);

            if (entity == null) throw new Exception("Error deleting entity.");

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity == null) throw new Exception("Entity not found");

            return entity;
        }

        public async Task<PaginationResult<TEntity>> Get(int pageIndex, int pageSize)
        {
            var entityList = await _dbSet.GetPage(pageIndex, pageSize);

            return entityList;
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            var existingEntity = await Get(id);

            if (id != existingEntity.Id) throw new Exception("Id doesn't match");

            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
