using Main.Infrastructure.AppDbContext;
using Main.Infrastructure.Repository;

namespace Main.Application.Factory
{
    public interface IMongoUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }

        Task<bool> Commit();
    }

    public class MongoUnitOfWork : IMongoUnitOfWork
    {
        private readonly IMongoDbContext _context;

        public MongoUnitOfWork(IMongoDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product => new ProductRepository(_context);

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
