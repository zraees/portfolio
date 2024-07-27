using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace OnionArchitectureImplementation.Api.Filters
{
     
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Log the exception
            LogException(actionExecutedContext.Exception);

            // Determine the appropriate HTTP status code based on the exception type
            var statusCode = DetermineStatusCode(actionExecutedContext.Exception);

            // Create a response object with the appropriate status code and error message
            var response = actionExecutedContext.Request.CreateResponse((HttpStatusCode)statusCode, new
            {
                Error = actionExecutedContext.Exception.Message
            });

            // Set the response in the action executed context
            actionExecutedContext.Response = response;
        }

        private void LogException(Exception exception)
        {
            // Implement your logging mechanism here
            Console.WriteLine($"An exception occurred: {exception.Message}");
        }

        private int DetermineStatusCode(Exception exception)
        {
            // Determine the appropriate HTTP status code based on the exception type
            if (exception is ArgumentException)
            {
                return (int)HttpStatusCode.BadRequest;
            }
            else if (exception is UnauthorizedAccessException)
            {
                return (int)HttpStatusCode.Unauthorized;
            }
            //else if (exception is NotFoundException)
            //{
            //    return (int)HttpStatusCode.NotFound;
            //}
            else
            {
                return (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}