using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ToroChallenge.Application.UseCases.Investimentos;
using ToroChallenge.Application.UseCases.Saldos;
using ToroChallenge.Data.MongoDb;
using ToroChallenge.Domain.Repositories;
using ToroChallenge.Domain.Services;

namespace ToroChallenge.Api.ServiceCollections
{
    public static class ServiceCollectiosns
    {
        public static IServiceCollection AddConfigureServices(this IServiceCollection services)
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
            services.AddTransient<IInvestimentoService, InvestimentoService>();
            services.AddTransient<ISaldoService, SaldoService>();
            //Servicos
            services.AddTransient<IInvestimentoQueryRepository, InvestimentoQueryRepository>();
            services.AddTransient<IInvestimentoCommandRepository, InvestimentoCommandRepository>();
            services.AddTransient<ISaldoQueryRepository, SaldoQueryRepository>();
            services.AddTransient<ISaldoCommandRepository, SaldoCommandRepository>();
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
