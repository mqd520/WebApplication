namespace WebApplication2.Exceptions
{
    public class CustomBusinessException : ApplicationException
    {
        public int ErrorCode { private set; get; }

        public CustomBusinessException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
