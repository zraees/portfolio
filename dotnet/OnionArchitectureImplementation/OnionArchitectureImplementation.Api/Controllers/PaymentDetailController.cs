using FluentResults;
using OnionArchitectureImplementation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace OnionArchitectureImplementation.Api.Controllers
{
    public class PaymentDetailController : BaseApiController
    {
        private readonly IPaymentDetailService _paymentDetailService;
        public PaymentDetailController()
        {
            // Constructor implementation
        }

        public PaymentDetailController(IPaymentDetailService paymentDetailService)
        {
            _paymentDetailService = paymentDetailService;
        }

        /// <summary>
        /// To get all records
        /// </summary>
        /// <remarks>
        /// To get all payment detail of customers
        /// </remarks>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var result = _paymentDetailService.GetAll(); 

            return Ok(new { Data = result.Value });
        }

        public IHttpActionResult GetByID(int id)
        {
            var result = _paymentDetailService.GetById(id);

            if (result.IsFailed)
            {
                return ResultFailerHandler(result);
            }

            return Ok(new { Data = result.Value });
        }
    }
}
