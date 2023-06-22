using MediatR;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public interface IInvestimentoHandler : IRequestHandler<InvestimentoCommand, InvestimentoResponse[]>
    {
    }
}
