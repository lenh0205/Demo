using Main.Base;
using Main.DataAccess.AppDbContext;
using Main.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Main.DataAccess.Repository
{
    public interface IItemRepository : IBaseRepository<Item, ApplicationDbContext> 
    {
        public string TestItemRepository();
    }

    public class ItemRepository : BaseRepository<Item, ApplicationDbContext>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }
        public string TestItemRepository()
        {
            return "TestItemRepository";
        }
    }
}
