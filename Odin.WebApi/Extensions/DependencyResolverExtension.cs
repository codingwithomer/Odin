using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Odin.BLL.Managers;
using Odin.BLL.Services;
using Odin.DataAccess.Repositories.Concretes;
using Odin.DataAccess.Repositories.Interfaces;
using Odin.Models;
using Odin.WebApi.Validators;

namespace Odin.WebApi.Extensions
{
    public static class DependencyResolverExtension
    {
        public static IServiceCollection InstallServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICustomerService, CustomerManager>();

            services.AddTransient<IValidator<CustomerDTO>,CustomerValidator>();
            services.AddTransient<IValidator<ProductDTO>,ProductValidator>();

            return services;
        }
    }
}
