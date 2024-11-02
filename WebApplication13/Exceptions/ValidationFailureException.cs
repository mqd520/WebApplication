namespace WebApplication13.Exceptions
{
    public class ValidationFailureException : ApplicationException
    {
        public ValidationFailureException(string? message)
            : base(message)
        {

        }
    }
}
