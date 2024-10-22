using Main.Base;

namespace Main.BusinessServices
{
    public interface IItemService : IBaseBusinessService
    {
        public string GetOne();
    }

    public class ItemService : BaseBusinessService, IItemService
    {
        public ItemService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public string GetOne()
        {
            return "hello";
        }
    }

    public class Item
    {
        public int Id { get; set; }
    }
}
