namespace Main.Services
{
    public interface IBusinessServicesFactory
    {
        public ItemService ItemService { get; }

    }

    public class BusinessServicesFactory : IBusinessServicesFactory
    {
        IServiceProvider _serviceProvider;
        public BusinessServicesFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Dictionary<string, IBusinessService> CacheServiceIntances = new Dictionary<string, IBusinessService>();

        public ItemService? _ItemService { get; set; }
        public ItemService ItemService
        {
            get
            {
                if (_ItemService == null) _ItemService = new ItemService();
                return _ItemService;
            }
        }
    }

    public interface IBusinessService { }
}


