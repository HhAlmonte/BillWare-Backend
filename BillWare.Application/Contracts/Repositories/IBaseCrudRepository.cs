using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Contracts.Persistence
{
    public interface IBaseCrudRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateEntityAsync(TEntity entity);
        Task<bool> DeleteEntityByIdAsync(TEntity entity);
        Task<TEntity> GetEntityByIdAsync(int id);
        Task<TEntity> UpdateEntityAsync(TEntity entity);

        Task<PaginationResult<TEntity>> GetEntitiesPagedWithSearch(string searchValue, int pageIndex, int pageSize);
        Task<PaginationResult<TEntity>> GetEntitiesPaged(int pageIndex, int pageSize);
    }
}
