using OnionArchitectureImplementation.Domain.Entities;
using OnionArchitectureImplementation.Infrastructure.Repository;
using System;

namespace OnionArchitectureImplementation.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PaymentDetail> PaymentDetails { get; }
        int SaveChanges();
    }
}
