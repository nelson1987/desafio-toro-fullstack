using MediatR;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public class SaldoCommand : IRequest<SaldoResponse>
    {
        public string LoginUsuario { get; set; }
    }
}
