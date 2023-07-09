using MassTransit;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEventConsumerDefinition :
        ConsumerDefinition<ContaAbertaEventConsumer>
    {
        public ContaAbertaEventConsumerDefinition()
        {
            // override the default endpoint name
            EndpointName = "pagamento-realizado";

            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<ContaAbertaEventConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(5, 10, 100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}