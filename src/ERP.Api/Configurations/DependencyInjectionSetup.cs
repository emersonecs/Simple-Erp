using ERP.Application.Interfaces;
using ERP.Application.Services;
using ERP.Domain.Interfaces;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.Repository;

namespace ERP.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ISupplierAppService, SupplierAppService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IClientRepository, ClientRepository>();


            services.AddScoped<NotificationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
