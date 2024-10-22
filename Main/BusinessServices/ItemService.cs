using Main.Base;

namespace Main.BusinessServices
{
    public class ItemService : BaseBusinessService
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
