namespace WebApplication21.Tools
{
    public static class WebRequestTool
    {
        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request != null && request.Headers != null)
            {
                return request.Headers.XRequestedWith == "XMLHttpRequest";
            }

            return false;
        }

        public static bool IsAjaxRequest()
        {
            var httpContext = ServiceLocator.GetCurrentHttpContext();
            return IsAjaxRequest(httpContext?.Request ?? null!);
        }

        public static string GetRealClientIp(HttpRequest request)
        {
            var ip4 = request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip4))
            {
                ip4 = request.Headers["X-Forwarded-Proto"].FirstOrDefault();
            }
            if (string.IsNullOrEmpty(ip4))
            {
                ip4 = request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            }

            return ip4 ?? "";
        }
    }
}
