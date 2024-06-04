using CleanArchWithCQRSPattern.Domain.Entities;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly BlogDbContext _blogDbContext;

    public GenericRepository(BlogDbContext blogDbContext)
    {
        _blogDbContext = blogDbContext;
    }

    public void Create(T entity)
    {
        _blogDbContext.Add<T>(entity);
    }

    public async Task CreateAsync(T entity)
    {
        await _blogDbContext.AddAsync<T>(entity).ConfigureAwait(false);
        await _blogDbContext.SaveChangesAsync().ConfigureAwait(false);
        return;
    }

    public Guid Delete(Guid id)
    {
        var blog = GetByIdAsync(id).Result;
        _blogDbContext.Remove<T>(blog);
        _blogDbContext.SaveChanges();
        return blog.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        var blog = await GetByIdAsync(id).ConfigureAwait(false);
        _blogDbContext.Remove<T>(blog);
        await _blogDbContext.SaveChangesAsync().ConfigureAwait(false);
        return blog.Id;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _blogDbContext.Set<T>().ToListAsync().ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _blogDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
    }

    public Guid Update(Guid id, T entity)
    {
        _blogDbContext.Attach<T>(entity);
        _blogDbContext.Entry(entity).State = EntityState.Modified;

        _blogDbContext.SaveChanges();
        return id;
    }

    public async Task<Guid> UpdateAsync(Guid id, T entity)
    {
        _blogDbContext.Attach<T>(entity);
        _blogDbContext.Entry(entity).State = EntityState.Modified;

        await _blogDbContext.SaveChangesAsync().ConfigureAwait(false);
        return id;
    }
}