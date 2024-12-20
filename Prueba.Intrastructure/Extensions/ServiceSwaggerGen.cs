using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Prueba.Intrastructure.Extensions
{
    public static class ServiceSwaggerGen
    {
        public static WebApplicationBuilder AddServicesSwaggerGen(this WebApplicationBuilder builder)
        {

            //   Para la configuración del Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Prueba.Api",
                    Version = "v1",
                    Description = "Esto es una API de pruebas para una base de datos de Postgres SQL y net core 8.0"
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme",
                //    Name = "Authorization",
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        },
                //        new List<string>()
                //    }
                //});
            });

            return builder;
        }

    }
}
