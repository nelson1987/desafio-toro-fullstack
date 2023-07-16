using RabbitMQ.Client;
using System.Text;

namespace ToroChallenge.Application.Utils
{
    public class ProduceMessage : IBusMessage
    {
        public void Init(IEvent message)
        {
            var factory = new ConnectionFactory { 
                HostName = "localhost", 
                UserName = "guest", 
                Password = "guest" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: message.QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var body = Encoding.UTF8.GetBytes(message.ToJson());

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: message.QueueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
