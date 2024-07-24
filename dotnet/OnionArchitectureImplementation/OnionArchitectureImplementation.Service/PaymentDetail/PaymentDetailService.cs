using FluentResults;
using OnionArchitectureImplementation.Domain;
using OnionArchitectureImplementation.Domain.Entities;
using OnionArchitectureImplementation.Domain.Enums;
using OnionArchitectureImplementation.Infrastructure;
using OnionArchitectureImplementation.Service.Exceptions;
using System;
using System.Collections.Generic; 

namespace OnionArchitectureImplementation.Service
{
    public class PaymentDetailService : IPaymentDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result<PaymentDetail> GetById(int id)
        {
            var paymentDetail = _unitOfWork.PaymentDetails.Get(id);

            if (paymentDetail == null)
            {
                return new RecordNotFoundError($"Payment detail with id {id} is not found");
            }

            return paymentDetail;
        }

        public Result<IEnumerable<PaymentDetail>> GetAll()
        {
            return Result.Ok(_unitOfWork.PaymentDetails.GetAll());
        }

        public virtual Result Create(PaymentDetail PaymentDetail)
        {
            // some business validations
            // return new ValidationError("Card number is invalid");

            _unitOfWork.PaymentDetails.Add(PaymentDetail);
            _unitOfWork.SaveChanges();

            return Result.Ok();
        }

        public virtual Result Update(PaymentDetail PaymentDetail)
        {
            // some business validations
            // return new ValidationError("Card number is invalid");

            _unitOfWork.PaymentDetails.Update(PaymentDetail);
            _unitOfWork.SaveChanges();

            return Result.Ok();
        }

        public virtual Result Delete(int id)
        {
            var paymentDetail = _unitOfWork.PaymentDetails.Get(id);

            if (paymentDetail == null)
            {
                return new RecordNotFoundError($"Payment detail with id {id} is not found");
            }

            _unitOfWork.PaymentDetails.Remove(paymentDetail);
            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}
