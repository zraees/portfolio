using FluentResults;
using OnionArchitectureImplementation.Domain.Entities;
using System.Collections.Generic;

namespace OnionArchitectureImplementation.Service
{
    public interface IPaymentDetailService
    {
        Result<PaymentDetail> GetById(int id);

        Result<IEnumerable<PaymentDetail>> GetAll();

        Result Create(PaymentDetail PaymentDetail);

        Result Update(PaymentDetail PaymentDetail);

        Result Delete(int id);
    }
}
