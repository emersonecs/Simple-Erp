using ERP.Application.AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.Services;
using ERP.Domain.Interfaces;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ERP.UI.Web
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Configuration.AddUserSecrets<App>();

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["DbConnection"]);
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
#endif

            builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile), typeof(ViewModelToViewModelMappingProfile));
            builder.Services.AddScoped<NotificationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IProductAppService, ProductAppService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<ISupplierAppService, SupplierAppService>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

            return builder.Build();
        }
    }
}