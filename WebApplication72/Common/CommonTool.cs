using WebApplication72.Def;

namespace WebApplication72.Common
{
    public static class CommonTool
    {
        public static ApiResultData CreateApiResult(bool success = true
            , string msg = ""
            , object data = default!)
        {
            return new ApiResultData
            {
                Success = success,
                Msg = msg,
                Data = data
            };
        }

        public static string CreateCustomerId(int length = 5)
        {
            var chArr = new char[length];
            for (int i = 0; i < length; i++)
            {
                int rand = RandTool.CreateRandValWithMinMax(65, 90);
                chArr[i] = (char)rand;
            }
            return string.Join("", chArr);
        }
    }
}
