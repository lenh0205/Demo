using Main.Application.Base;
using Main.Application.DendencyInjection;
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
        public ItemRepository(IRepositoryDependencies respositoryDependency) : base(respositoryDependency.ApplicationDbContext)
        {
        }

        public string TestItemRepository()
        {
            return "TestItemRepository";
        }
    }
}
