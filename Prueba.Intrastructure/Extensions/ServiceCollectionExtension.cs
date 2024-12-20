using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prueba.Core.Helpers;
using Prueba.Core.Interfaces;
using Prueba.Core.Services;
using Prueba.Intrastructure.Repositories;

namespace Prueba.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            //-- Dependencias propias - (Inyeccion de dependencias)  --//
            builder.Services.AddTransient<IUsersRepository, UsersRepository>();
            builder.Services.AddTransient<IUsersService, UsersService>();
            builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
            builder.Services.AddTransient<IProductsService, ProductsService>();
            builder.Services.AddTransient<ITransactionsRepository, TransactionsRepository>();
            builder.Services.AddTransient<ITransactionsService, TransactionsService>();

            builder.Services.AddTransient<IAutoMapperData, AutoMapperData>();
            

            return builder;
        }
    }
}
