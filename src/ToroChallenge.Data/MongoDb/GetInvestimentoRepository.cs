﻿using Microsoft.Extensions.Logging;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{
    public class InvestimentoQueryRepository : IInvestimentoQueryRepository
    {
        private readonly ILogger<InvestimentoQueryRepository> _logger;

        public InvestimentoQueryRepository(ILogger<InvestimentoQueryRepository> logger)
        {
            _logger = logger;
        }

        public Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Teste: {command}", loginUsuario);
            throw new NotImplementedException();
        }
    }
}
