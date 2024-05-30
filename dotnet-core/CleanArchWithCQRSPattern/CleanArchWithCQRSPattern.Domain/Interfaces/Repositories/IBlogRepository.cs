using CleanArchWithCQRSPattern.Domain.Entities;

namespace CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;

interface IBlogRepository<T> : IGenericRepository<T> where T : BaseEntity
{

}