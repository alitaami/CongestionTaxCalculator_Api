using CongestionTaxCalculator_Project.Services.Interfaces;
using CongestionTaxCalculator_Project.Services;
using CongestionTAxCalculator_Project.DB.CongestionTaxCalculatorApp.Data;
using CongestionTAxCalculator_Project.Services.Interfaces;
using CongestionTAxCalculator_Project.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public static class ServiceExtensions
{
    public static IServiceCollection AddCustomServicesAndDbContextAndSwagger(this IServiceCollection services, string connectionString)
    {
        return services
            .AddCustomServices()
            .AddCustomDbContext(connectionString)
            .AddSwagger();
    }
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<ICongestionTax, CongestionTax>();
        services.AddTransient<ITaxRuleLoder, TaxRuleLoder>();

        return services;
    }

    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CongestionTaxContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        // Register the Swagger generator
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
        });

        return services;
    }
}
