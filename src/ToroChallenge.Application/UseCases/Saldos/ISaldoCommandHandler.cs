using MediatR;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public interface ISaldoCommandHandler : IRequestHandler<SaldoCommand, SaldoResponse>
    {
        //Task<InvestimentoResponse> Handle(InvestimentoCommand request, CancellationToken cancellationToken);
    }
}
