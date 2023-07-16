using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilaController : ControllerBase
    {
        private readonly ILogger<FilaController> _logger;

        public FilaController(ILogger<FilaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
    public class CustomErrorQueueNameFormatter : IErrorQueueNameFormatter
    {
        public string FormatErrorQueueName(string queueName)
        {
            return $"{queueName}_erros";
        }
    }
    public class CustomDeadLetterQueueNameFormatter : IDeadLetterQueueNameFormatter
    {
        public string FormatDeadLetterQueueName(string queueName)
        {
            return $"{queueName}.dead";
        }
    }
    public record CartaAbertaEvent
    {
        string Name { get; init; }
    }
    public record CartaAbertaEventConsumer : IConsumer<CartaAbertaEvent>
    {
        string Name { get; init; }

        public async Task Consume(ConsumeContext<CartaAbertaEvent> context)
        {
            throw new NotImplementedException();
        }
    }
    public record CartaAbertaEventFault : Fault<CartaAbertaEvent>
    {
        public CartaAbertaEvent Message => throw new NotImplementedException();

        public Guid FaultId => throw new NotImplementedException();

        public Guid? FaultedMessageId => throw new NotImplementedException();

        public DateTime Timestamp => throw new NotImplementedException();

        public ExceptionInfo[] Exceptions => throw new NotImplementedException();

        public HostInfo Host => throw new NotImplementedException();

        public string[] FaultMessageTypes => throw new NotImplementedException();
    }
    public class CartaAbertaEventConsumerDefinition :
        ConsumerDefinition<CartaAbertaEventConsumer>
    {
        public CartaAbertaEventConsumerDefinition()
        {
            // override the default endpoint name
            EndpointName = "carta.aberta.event.on-carta-aberta-event";
            ConcurrentMessageLimit = 8;
        }
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<CartaAbertaEventConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(5, 10, 100, 200, 500, 800, 1000));
            var rmq = endpointConfigurator as IRabbitMqReceiveEndpointConfigurator;

            rmq.Bind("carta.aberta.event", x =>
            {
                x.RoutingKey = "on-carta-aberta-event";
                x.Durable = true;
            });
            //rmq.Bind(deadLetterExchangeName, x =>
            //{
            //    x.RoutingKey = deadLetterRoutingKeyName;
            //    x.Durable = false;
            //});

            //rmq.BindDeadLetterQueue(deadLetterExchangeName, deadLetterQueueName, cfg =>
            //{
            //    //cfg.SetExchangeArgument("x-message-ttl", TimeSpan.FromSeconds(60));
            //    cfg.Durable = true;
            //    cfg.RoutingKey = deadLetterRoutingKeyName;
            //});
        }
    }
}