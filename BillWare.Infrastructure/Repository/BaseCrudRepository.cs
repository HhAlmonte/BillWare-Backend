using BillWare.Application.Shared;
using BillWare.Application.Shared.Entities;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<PaginationResult<TEntity>> Get(int pageIndex, int pageSize)
        {
            var entityList = await _dbSet.GetPage(pageIndex, pageSize);

            return entityList;
        }

        public async Task<PaginationResult<TEntity>> GetWithSearch(string searchValue, int pageIndex, int pageSize)
        {
            var query = _dbSet.AsQueryable();

            int intValue;
            bool isInt = int.TryParse(searchValue, out intValue);

            Expression<Func<TEntity, bool>> condition;
            if (isInt)
            {
                condition = BuildIntegerCondition(searchValue);
            }
            else
            {
                condition = BuildStringCondition(searchValue);
            }

            query = query.Where(condition);

            var result = await query.GetPage(pageIndex, pageSize);

            return result;
        }

        private Expression<Func<TEntity, bool>> BuildIntegerCondition(string searchValue)
        {
            int intValue = int.Parse(searchValue);

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, "Id");
            var constant = Expression.Constant(intValue, typeof(int));
            var equality = Expression.Equal(property, constant);

            return Expression.Lambda<Func<TEntity, bool>>(equality, parameter);
        }

        private Expression<Func<TEntity, bool>> BuildStringCondition(string searchValue)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var properties = typeof(TEntity).GetProperties().Where(p => p.PropertyType == typeof(string));
            var containsMethods = typeof(string).GetMethods().Where(m => m.Name == "Contains");

            Expression orCondition = Expression.Constant(false);
            foreach (var property in properties)
            {
                var propertyExpr = Expression.Property(parameter, property);
                var containsMethod = containsMethods.First(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string));
                var callMethodExpr = Expression.Call(propertyExpr, containsMethod, Expression.Constant(searchValue));

                orCondition = Expression.OrElse(orCondition, callMethodExpr);
            }

            return Expression.Lambda<Func<TEntity, bool>>(orCondition, parameter);
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity == null) throw new Exception("Entity not found");

            return entity;
        }
    }
}
