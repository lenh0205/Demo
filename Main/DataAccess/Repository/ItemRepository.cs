using Main.Application.Base;
using Main.DataAccess.AppDbContext;
using Main.DataAccess.Entities;

namespace Main.DataAccess.Repository
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
