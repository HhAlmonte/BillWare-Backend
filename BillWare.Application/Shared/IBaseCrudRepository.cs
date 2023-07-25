using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Shared
{
    public interface IBaseCrudRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> Delete(int id);
        Task<TEntity> Update(int id, TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Get(int id);
        Task<PaginationResult<TEntity>> Get(int pageIndex, int pageSize);
    }
}
