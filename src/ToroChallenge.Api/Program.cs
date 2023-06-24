using FluentValidation;
using ToroChallenge.Api.ServiceCollections;
using ToroChallenge.Application.UseCases.Patrimonios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConfigureServices();

builder.Services.AddValidatorsFromAssemblyContaining<PatrimonioValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

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

app.Run();

