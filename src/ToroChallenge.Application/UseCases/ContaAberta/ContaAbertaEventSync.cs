using MediatR;

namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEventSync : IRequest<ContaAbertaEventSyncResponse>
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }
    }
}