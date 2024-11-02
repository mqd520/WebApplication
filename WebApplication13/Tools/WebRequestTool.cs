namespace WebApplication13.Tools
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
    }
}
