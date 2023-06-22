using MediatR;
using ToroChallenge.Application.UseCases.Investimentos;
using ToroChallenge.Application.UseCases.Saldos;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioHandler : IRequestHandler<PatrimonioCommand, PatrimonioResponse>
    {
        private readonly IInvestimentoHandler investimentoHandler;
        private readonly ISaldoCommandHandler saldoCommandHandler;

        public PatrimonioHandler(IInvestimentoHandler investimentoHandler, ISaldoCommandHandler saldoCommandHandler)
        {
            this.investimentoHandler = investimentoHandler;
            this.saldoCommandHandler = saldoCommandHandler;
        }

        public async Task<PatrimonioResponse> Handle(PatrimonioCommand request, CancellationToken cancellationToken)
        {
            var response = new PatrimonioResponse();
            //TODO: Melhorar esse código
            response.Ativos = await investimentoHandler.Handle(new InvestimentoCommand() { LoginUsuario = request.LoginUsuario }, cancellationToken); ;
            response.Saldo = await saldoCommandHandler.Handle(new SaldoCommand() { LoginUsuario = request.LoginUsuario }, cancellationToken);
            return response;
        }
    }
}
