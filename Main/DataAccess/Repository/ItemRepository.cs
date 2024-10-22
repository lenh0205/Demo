using Main.Base;
using Main.DataAccess.AppDbContext;
using Main.DataAccess.Entities;

namespace Main.DataAccess.Repository
{
    public class ItemRepository : BaseRepository<Item, ApplicationDbContext>
    {
        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }
    }
}
