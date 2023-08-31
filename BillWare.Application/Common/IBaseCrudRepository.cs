using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Shared
{
    public interface IBaseCrudRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> DeleteEntityByIdAsync(int id);
        Task<TEntity> GetEntityByIdAsync(int id);
        Task<TEntity> UpdateEntityAsync(TEntity entity);
        Task<TEntity> CreateEntityAsync(TEntity entity);
        Task<PaginationResult<TEntity>> GetEntitiesPagedWithSearch(string searchValue, int pageIndex, int pageSize);
        Task<PaginationResult<TEntity>> GetEntitiesPaged(int pageIndex, int pageSize);
    }
}
