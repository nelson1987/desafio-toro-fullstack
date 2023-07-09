﻿using MediatR;
using Microsoft.Extensions.Logging;
using ToroChallenge.Application.UseCases.Investimentos;
using ToroChallenge.Application.UseCases.Saldos;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioHandler : IRequestHandler<PatrimonioCommand, ResponseResult<PatrimonioResponse>>
    {
        private readonly ILogger<PatrimonioHandler> _logger;
        private readonly IInvestimentoHandler _investimentoHandler;
        private readonly ISaldoCommandHandler _saldoCommandHandler;

        public PatrimonioHandler(IInvestimentoHandler investimentoHandler, ISaldoCommandHandler saldoCommandHandler, ILogger<PatrimonioHandler> logger)
        {
            _investimentoHandler = investimentoHandler;
            _saldoCommandHandler = saldoCommandHandler;
            _logger = logger;
        }

        public async Task<ResponseResult<PatrimonioResponse>> Handle(PatrimonioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", request.ToJson());
            request = new PatrimonioCommand();

            ////TODO: Melhorar esse código
            //response.Ativos = await _investimentoHandler.Handle(new InvestimentoCommand() { LoginUsuario = request.LoginUsuario }, cancellationToken).ConfigureAwait(true);
            //response.Saldo = await _saldoCommandHandler.Handle(new SaldoCommand() { LoginUsuario = request.LoginUsuario }, cancellationToken).ConfigureAwait(true);
            return new ResponseResult<PatrimonioResponse>(400, request.GetValidation().ToDictionary());
        }
    }
}
