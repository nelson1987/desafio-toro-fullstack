using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Domain.Repositories;

namespace ToroChallenge.Data.MongoDb
{

    public class MongoDbSession
    {
        //public static string ConnectionString { get; set; }
        //public static string DatabaseName { get; set; }
        //public static bool IsSSL { get; set; }
        private readonly IMongoDatabase _database;

        public MongoDbSession()
        {
            try
            {
                //MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                //if (IsSSL)
                //{
                //    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                //}
                //var mongoClient = new MongoClient(settings);
                //_database = mongoClient.GetDatabase(DatabaseName);

                var client = new MongoClient("mongodb://mongo:mongo1A2b3C@localhost:27017/admin");
                _database = client.GetDatabase("BookStore");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Book> Contas => _database.GetCollection<Book>("Books");
    }
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
