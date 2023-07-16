using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using System.IO.Compression;
using System.Reflection;
using ToroChallenge.Api.ServiceCollections;
using ToroChallenge.Application.UseCases.ContaAberta;
using ToroChallenge.Application.UseCases.Patrimonios;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddSerilog(builder.Configuration, "API Observability");

    Serilog.Log.Information("Starting API");


    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(x =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });

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

    string nomeFila = "xpinc.teste.on-customer-created-event";
    string nomeExchange = "xpinc.customer.exchange";
    string nomeRoutingKey = "on-customer-created";
    string deadLetterQueueName = "xpinc.teste.on-customer-created-event-dead";
    string deadLetterExchangeName = "xpinc.customer.exchange.dead";
    string deadLetterRoutingKeyName = "on-customer-created-dead";
    string nomeFilaTransferencia = "xpinc.transferencia.on-customer-created-event";
    string nomeFilaAssessor = "xpinc.assessor.on-customer-created-event";

    builder.Services.AddMassTransit(x =>
    {

        //x.SetKebabCaseEndpointNameFormatter();
        //x.SetEndpointNameFormatter(new XpEndpointNameFormatter());
        //x.AddConsumer<ContaAbertaEventConsumer>();
        x.AddConsumer<ContaAbertaEventConsumer>(typeof(ContaAbertaEventConsumerDefinition));
        /*
        x.AddConfigureEndpointsCallback((_, cfg) =>
        {
            cfg.ConfigureDefaultDeadLetterTransport();
        });
        */

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.UseRawJsonSerializer();
            cfg.UseMessageRetry(x => x.Interval(2, 1000));
            cfg.ReceiveEndpoint(deadLetterQueueName, e =>
            {
                e.SetQueueArgument("x-expires", TimeSpan.FromSeconds(10));
                e.Bind(deadLetterExchangeName, x =>
                {
                    x.RoutingKey = deadLetterRoutingKeyName;
                });
            });
            /*
            cfg.ReceiveEndpoint(nomeFila, e =>
            {
                //e.ConfigureDefaultDeadLetterTransport();
                //e.ExchangeType = ExchangeType.FanOut.ToString();
                e.SetQueueArgument("x-dead-letter-exchange", deadLetterExchangeName);
                //e.SetQueueArgument("x-dead-letter-routing-key", deadLetterRoutingKeyName);
                e.SetQueueArgument("x-dead-letter-routing-key", deadLetterRoutingKeyName);
                e.SetQueueArgument("x-expires", TimeSpan.FromSeconds(10));
                e.Bind(nomeExchange, x =>
                {
                    x.RoutingKey = nomeRoutingKey;
                });
                e.BindDeadLetterQueue(deadLetterExchangeName), deadLetterQueueName, cfg =>
                {
                    cfg.Durable = true;
                    cfg.AutoDelete = false;
                    cfg.Exclusive = false;
                    cfg.RoutingKey = deadLetterRoutingKeyName;
                });
                e.ConfigureConsumer<ContaAbertaEventConsumer>(context);
            });

            */


            /*
            cfg.Message<MessageEvent>(x =>
            {
                x.SetEntityName("omg-we-got-one");
            });
            cfg.UseRawJsonSerializer();
            //    cfg.
            //    // Create the dead letter queue
            //    var queue = context.Get<IMessageBus>().CreateQueue("teste.dead");

            //    // Create the dead letter exchange
            //    var exchange = context.Get<IMessageBus>().CreateExchange("exch.dead");

            //    // Bind the dead letter exchange to the dead letter queue
            //    exchange.Bind("routing.dead", queue);
            //}
            cfg.ReceiveEndpoint(nomeFila, e =>
            {
                cfg.AutoDelete = true;
                //e.BindDeadLetterQueue("dead-letter-queue-name");
                e.ConfigureDefaultDeadLetterTransport();
                e.DiscardSkippedMessages();
                e.PublishFaults = true;
                e.Bind(nomeExchange, x =>
                {
                    x.RoutingKey = nomeRoutingKey;
                });
                e.BindDeadLetterQueue(deadLetterExchangeName, deadLetterQueueName, x =>
                {
                    x.RoutingKey = nomeFila;
                });
                e.ConfigureConsumer<MessageConsumer>(context);
            });
            cfg.ReceiveEndpoint(deadLetterQueueName, e =>
            {
                e.Bind(deadLetterExchangeName, x =>
                {
                    x.RoutingKey = deadLetterRoutingKeyName;
                });
            });
            */
            //cfg.ReceiveEndpoint("nomeFila", e =>
            //{
            //    e.ConfigureDefaultDeadLetterTransport();
            //    e.PublishFaults = true;
            //    e.Bind(nomeExchange, x =>
            //    {
            //        x.RoutingKey = nomeRoutingKey;
            //    });
            //    e.ConfigureConsumer<MessageConsumer>(context);
            //});

            //cfg.Message<ContaAbertaEvent>(x => x.SetEntityName("conta-aberta"));
            //cfg.Send<ContaAbertaEvent>(x =>
            //{
            //    x.UseCorrelationId(context => context.Id);
            //    x.UseRoutingKeyFormatter(context => context.Message.QueueName);
            //});
            //cfg.Publish<ContaAbertaEvent>(e =>
            //{
            //    e.BindQueue(nomeExchange, nomeFila);
            //});
            /*
            cfg.ReceiveEndpoint(nomeFilaTransferencia, e =>
            {
                //e.ConfigureDeadLetter(x =>
                //{
                //    //x.UseBind(x => {x. });
                //    x.UseFilter(new DeadLetterTransportFilter());
                //});
                e.Bind(nomeExchange, x =>
                {
                    x.RoutingKey = nomeRoutingKey;
                });
            });
            cfg.ReceiveEndpoint(nomeFilaAssessor, e =>
            {
                e.Bind(nomeExchange, x =>
                {
                    x.RoutingKey = nomeRoutingKey;
                });
            });
            */
            cfg.ConfigureEndpoints(context);
        });
    });
    //builder.Services.AddTransient<IBusMessage, ProduceMessage>();
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