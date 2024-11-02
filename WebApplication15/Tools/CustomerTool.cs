namespace WebApplication15.Tools
{
    public static class CustomerTool
    {
        public static string CreateCustomerId()
        {
            var ran = CommonTool.CreateRandom();
            char[] arr = new char[5];
            for (int i = 0; i < arr.Length; i++)
            {
                var value = ran.Next(65, 91);
                arr[i] = (char)value;
            }

            return new string(arr);
        }
    }
}
