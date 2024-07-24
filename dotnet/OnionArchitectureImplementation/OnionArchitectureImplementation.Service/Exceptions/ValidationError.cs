using FluentResults;

namespace OnionArchitectureImplementation.Service.Exceptions
{
    public class ValidationError : Error
    {
        public ValidationError(string message)
            : base(message)
        {
            
        }
    }
}
