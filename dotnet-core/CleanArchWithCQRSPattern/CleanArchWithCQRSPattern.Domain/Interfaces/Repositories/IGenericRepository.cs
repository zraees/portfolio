using CleanArchWithCQRSPattern.Domain.Entities;

namespace CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);

    Task CreateAsync(T entity);
    Task<Guid> DeleteAsync(Guid id);
    Task<Guid> UpdateAsync(Guid id, T entity);

    void Create(T entity);
    Guid Update(Guid id, T entity);
    Guid Delete(Guid id);
}
