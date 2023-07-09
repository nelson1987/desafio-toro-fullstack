using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ToroChallenge.Application.UseCases.Investimentos;
using ToroChallenge.Application.UseCases.Saldos;
using ToroChallenge.Application.Utils;
using ToroChallenge.Data.MongoDb;
using ToroChallenge.Data.Oracle;
using ToroChallenge.Domain.Repositories;
using ToroChallenge.Domain.Services;
using ToroChallenge.Service.Services;

namespace ToroChallenge.Api.ServiceCollections
{
    public static class ConfigureCollections
    {
        public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = typeof(InvestimentoHandler).GetTypeInfo().Assembly;
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(assembly);
            });
            services.AddFluentValidationAutoValidation();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Baas.Api", Version = "v1" }));
            //services.AddScoped<DbSession>();
            //services.AddScoped<MongoDbSession>();
            //Handlers
            services.AddTransient<IInvestimentoHandler, InvestimentoHandler>();
            services.AddTransient<ISaldoCommandHandler, SaldoCommandHandler>();
            //Servicos
            services.AddTransient<IInvestimentoService, InvestimentService>();
            services.AddTransient<IBalanceService, BalanceService>();
            //Servicos
            services.AddTransient<IInvestimentoQueryRepository, InvestimentoQueryRepository>();
            services.AddTransient<IInvestimentoCommandRepository, InvestimentoCommandRepository>();
            services.AddTransient<IBalanceQueryRepository, SaldoQueryRepository>();
            services.AddTransient<IBalanceCommandRepository, SaldoCommandRepository>();
            services.AddTransient<IApplicationResult, ApplicationResult>();


            services.AddScoped<MongoDbSession>();
            //services.Configure<BookStoreDatabaseSettings>(configuration.GetSection("BookStoreDatabase"));
            return services;

        }
        public static WebApplication AddCustomHealthChecks(this WebApplication app)
        {
            app.MapControllers();

            app.UseEndpoints(x =>
            {
                x.MapHealthChecks("/health/live", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
                {
                    Predicate = _ => false
                });
                x.MapHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
                {
                    Predicate = healthCheck => healthCheck.Tags.Contains("ready")
                });
            });
            return app;
        }
    }
}
