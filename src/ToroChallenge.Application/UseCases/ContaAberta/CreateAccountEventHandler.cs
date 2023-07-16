using MediatR;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class CreateAccountEventHandler : INotificationHandler<ClienteAlteradoEvent>
    {
        //private readonly ICreatedAccountEventRepository _repository;
        //
        //public CreateAccountEventHandler(ICreatedAccountEventRepository repository)
        //{
        //    _repository = repository;
        //}

        //public Task Handle(CreatedAccountEvent notification, CancellationToken cancellationToken)
        //{
        //    //_repository.Insert(AccountDTO.MappingFromEvent(notification));
        //    return Task.CompletedTask;
        //}

        public async Task Handle(ClienteAlteradoEvent notification, CancellationToken cancellationToken)
        {
            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "conta-aberta-event",
            //                       durable: false,
            //                       exclusive: false,
            //                       autoDelete: false,
            //                       arguments: null);


            //    var body = Encoding.UTF8.GetBytes(notification.ToJson());

            //    channel.BasicPublish(exchange: "",
            //                         routingKey: "conta-aberta-event",
            //                         basicProperties: null,
            //                         body: body);
        }
        //await Task.Delay(1000);
    }
}