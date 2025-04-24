using WebApplication38.Middlewares;

namespace WebApplication38.ApplicationBuilderExtension
{
    public static class JwtBearerParserMiddlewareExtension
    {
        public static IApplicationBuilder UseJwtBearerParser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtBearerParserMiddleware>();
        }
    }
}
