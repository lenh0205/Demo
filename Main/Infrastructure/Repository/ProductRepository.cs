using Main.Application.Base;
using Main.Infrastructure.AppDbContext;
using Main.Infrastructure.Entities;

namespace Main.Infrastructure.Repository
{
    public interface IProductRepository : IMongoRepository<Product>
    {
        string TestProductRepository();
    }

    // Implementation
    public class ProductRepository : BaseMongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDbContext context) : base(context)
        {
        }

        public string TestProductRepository()
        {
            return "TestProductRepository";
        }
    }
}
