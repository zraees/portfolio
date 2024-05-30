using CleanArchWithCQRSPattern.Domain.Entities;

namespace CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);

    void DeleteAsync(T entity);
    void UpdateAsync(T entity);

    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
