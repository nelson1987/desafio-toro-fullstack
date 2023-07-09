using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using System.IO.Compression;
using ToroChallenge.Api.ServiceCollections;
using ToroChallenge.Application.UseCases.ContaAberta;
using ToroChallenge.Application.UseCases.Patrimonios;
using ToroChallenge.Application.Utils;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddSerilog(builder.Configuration, "API Observability");

    Serilog.Log.Information("Starting API");


    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddConfigureServices(builder.Configuration);

    // Configura o modo de compressão
    builder.Services.Configure<GzipCompressionProviderOptions>(
        options => options.Level = CompressionLevel.Optimal);
    builder.Services.AddResponseCompression(options =>
    {
        options.Providers.Add<GzipCompressionProvider>();
        options.EnableForHttps = true;
    });

    builder.Services.AddValidatorsFromAssemblyContaining<PatrimonioValidator>();


    builder.Services.AddMassTransit(x =>
    {
        x.SetKebabCaseEndpointNameFormatter();
        x.AddConsumer<ContaAbertaEventConsumer>(typeof(ContaAbertaEventConsumerDefinition));

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);
        });
    });
    builder.Services.AddTransient<IBusMessage, ProcudeMessage>();
    //builder.Services.AddScoped<IPublishEndpoint>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        //app.UseSwaggerUI();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "app v1"));
    }
    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();

    app.UseSerilog();

    app.MapControllers();

    //app.UseEndpoints(x =>
    //{
    //    x.MapHealthChecks("/health/live", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
    //    {
    //        Predicate = _ => false
    //    });
    //    x.MapHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
    //    {
    //        Predicate = healthCheck => healthCheck.Tags.Contains("ready")
    //    });
    //});
    //app.UseHealthChecks("/health/live", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
    //{
    //    Predicate = _ => false
    //});
    app.Run();


}
catch (Exception ex)
{
    Serilog.Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Serilog.Log.Information("Server Shutting down...");
    Serilog.Log.CloseAndFlush();
}