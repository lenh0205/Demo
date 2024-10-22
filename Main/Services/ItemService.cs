namespace Main.Services
{
    public class ItemService : IBusinessService
    {
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
