using FluentResults;
using OnionArchitectureImplementation.Domain.Entities;
using OnionArchitectureImplementation.Service.Exceptions;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Filters;


namespace OnionArchitectureImplementation.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        internal IHttpActionResult ResultFailerHandler(Result<PaymentDetail> result)
        {
            if (result.HasError<RecordNotFoundError>())
            {
                return NotFound();
            }
            else 
            {
                return BadRequest(result.Errors.ToString());
            }
        }
    }
}