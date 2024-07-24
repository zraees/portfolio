using FluentResults;

namespace OnionArchitectureImplementation.Service.Exceptions
{
    public class RecordNotFoundError : Error
    {
        public RecordNotFoundError(string message)
            : base(message)
        {
            
        }
    }
}
