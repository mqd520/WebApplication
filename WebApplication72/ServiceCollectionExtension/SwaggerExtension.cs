using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApplication72.ServiceCollectionExtension
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //services.AddSwaggerGen(options =>
            //{
            //    var scheme = new OpenApiSecurityScheme()
            //    {
            //        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
            //        Reference = new OpenApiReference
            //        {
            //            Type = ReferenceType.SecurityScheme,
            //            Id = "Authorization"
            //        },
            //        Scheme = "oauth2",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //    };
            //    options.AddSecurityDefinition("Authorization", scheme);
            //    var requirement = new OpenApiSecurityRequirement();
            //    requirement[scheme] = new List<string>();
            //    options.AddSecurityRequirement(requirement);
            //});
        }
    }
}
