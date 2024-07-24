using OnionArchitectureImplementation.Domain.Entities;
using OnionArchitectureImplementation.Infrastructure.Repository;

namespace OnionArchitectureImplementation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaymentDetailContext _dbContext;
        private IRepository<PaymentDetail> _paymentDetailRepository;

        public UnitOfWork(PaymentDetailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<PaymentDetail> PaymentDetails
        {
            get
            {
                if (_paymentDetailRepository == null)
                {
                    _paymentDetailRepository = new Repository<PaymentDetail>(_dbContext);
                }
                return _paymentDetailRepository;
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
