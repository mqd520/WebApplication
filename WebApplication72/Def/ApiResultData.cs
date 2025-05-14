namespace WebApplication72.Def
{
    public class ApiResultData
    {
        public bool Success { get; set; } = false;

        public string Msg { get; set; } = string.Empty;

        public object Data { get; set; } = default!;
    }
}
