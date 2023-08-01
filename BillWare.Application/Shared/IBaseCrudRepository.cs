using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Shared
{
    public interface IBaseCrudRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> Delete(int id);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<PaginationResult<TEntity>> GetWithSearch(string searchValue, int pageIndex, int pageSize);
        Task<PaginationResult<TEntity>> Get(int pageIndex, int pageSize);
    }
}
