using CleanArchWithCQRSPattern.Domain.Entities;

namespace CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);

    Task CreateAsync(T entity);
    Task<int> DeleteAsync(Guid id);
    Task<int> UpdateAsync(Guid id, T entity);

    void Create(T entity);
    int Update(Guid id, T entity);
    int Delete(Guid id);
}
