using Main.Application.Base;
using Main.Infrastructure.AppDbContext;
using Main.Infrastructure.Entities;

namespace Main.Infrastructure.Repository
{
    public interface IItemRepository : IBaseRepository<Item, IApplicationDbContext>
    {
        public string TestItemRepository();
    }

    public class ItemRepository : BaseRepository<Item, IApplicationDbContext>, IItemRepository
    {
        public ItemRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public string TestItemRepository()
        {
            return "TestItemRepository";
        }
    }
}
