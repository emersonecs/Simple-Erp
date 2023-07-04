using ERP.Api.Configurations;
using ERP.Application.AutoMapper;
using ERP.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

#region ConfigureServices

builder.Services.AddDbContext<AppDbContext>(options =>
{
#if DEBUG
    options.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
    options.EnableSensitiveDataLogging();
#endif

    options.UseSqlServer(builder.Configuration["DbConnection"]);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile), typeof(ViewModelToViewModelMappingProfile));

builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjectionSetup();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new TypeFilterAttribute(typeof(NotificationFilter)));
    options.EnableEndpointRouting = false;
});

var app = builder.Build();

#endregion

#region Configure

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

