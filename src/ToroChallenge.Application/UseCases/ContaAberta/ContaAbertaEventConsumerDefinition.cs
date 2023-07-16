using MassTransit;
using MassTransit.Middleware;
using MassTransit.RabbitMqTransport;
using RabbitMQ.Client;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEventConsumerDefinition :
        ConsumerDefinition<ContaAbertaEventConsumer>
    {
        private const string queueName = "xpinc.teste.on-customer-created-event";
        private const string exchangeName = "xpinc.customer.exchange";
        private const string routingKeyName = "on-customer-created";
        private const string deadLetterQueueName = "xpinc.teste.on-customer-created-event-dead";
        private const string deadLetterExchangeName = "xpinc.customer.exchange.dead";
        private const string deadLetterRoutingKeyName = "on-customer-created-dead";
        public ContaAbertaEventConsumerDefinition()
        {
            // override the default endpoint name
            EndpointName = queueName;

            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<ContaAbertaEventConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(5, 10, 100, 200, 500, 800, 1000));
            
            if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
            {
                //endpointConfigurator.ConfigureDeadLetter(x =>
                //{
                //    x.UseFilter(new DeadLetterTransportFilter());
                //});
                rmq.Bind(exchangeName, x =>
                {
                    x.RoutingKey = routingKeyName;
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
}