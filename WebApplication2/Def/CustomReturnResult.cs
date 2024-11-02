using WebApplication2.Def.Enum;

namespace WebApplication2.Def
{
    public class CustomReturnResult
    {
        public bool IsSuccess;

        public int Code;

        public string? Message;

        public object? Data;

        public CustomReturnResult(bool success, int code, string? message, object? data)
        {
            IsSuccess = success;
            Code = code;
            Message = message;
            Data = data;
        }

        public static CustomReturnResult Success(object? data)
        {
            return new CustomReturnResult(true, (int)CustomReturnResultCodeEnum.NoError, null, data);
        }

        public static CustomReturnResult Fail(int code, string? message)
        {
            return new CustomReturnResult(false, (int)code, message, null);
        }

        public static CustomReturnResult Fail(int code, string? message, object data)
        {
            return new CustomReturnResult(false, (int)code, message, data);
        }
    }
}
