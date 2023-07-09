using MediatR;

namespace ToroChallenge.Application.Utils
{
    public interface IEvent : INotification
    {
        Guid CorrelationId { get; }
        string QueueName { get; }
    }
}
