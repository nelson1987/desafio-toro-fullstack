using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{
    public class InvestimentoQueryRepository : IInvestimentoQueryRepository
    {
        private readonly ILogger<InvestimentoQueryRepository> _logger;
        private readonly MongoDbSession _context;

        public InvestimentoQueryRepository(ILogger<InvestimentoQueryRepository> logger, MongoDbSession context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Investimento[]> GetAsync(string loginUsuario, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Teste: {command}", loginUsuario);
                await _context.Contas.InsertOneAsync(new Book() { Author = "Author", BookName = "BookName", Category = "Category", Price = 1.99M });
                var books = await _context.Contas.Find(_ => true).ToListAsync();
                return new List<Investimento>().ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Teste: {command}", loginUsuario);
                throw;
            }
        }
    }
}
