using Main.Base;
using Main.DataAccess.AppDbContext;
using Main.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Main.DataAccess.Repository
{
    public interface IItemRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext> 
        where TEntity : class
        where TContext : DbContext
    {
        public string TestItemRepository();
    }

    public class ItemRepository : BaseRepository<Item, ApplicationDbContext>, IItemRepository<Item, ApplicationDbContext>
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
