using OnionArchitectureImplementation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnionArchitectureImplementation.Api.Controllers
{
    public class PaymentDetailController : ApiController
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

        public IHttpActionResult Get()
        {
            var data = _paymentDetailService.GetAll(); 

            return Ok(new { Data = data.Value });
        }
    }
}
