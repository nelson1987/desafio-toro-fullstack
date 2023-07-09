using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEvent : IEvent
    {
        public Guid CorrelationId { get { return Guid.NewGuid(); } }
        //
        public string QueueName { get { return "Conta-Aberta-Event"; } }

        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }
    }
}