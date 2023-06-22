using MediatR;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoCommand : IRequest<InvestimentoResponse[]>
    {
        public string LoginUsuario { get; set; }
    }
}
