namespace Main.Base
{
    public interface IBaseBusinessService
    {
        public string TestBaseBusinessService();
    }

    public abstract class BaseBusinessService : IBaseBusinessService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseBusinessService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string TestBaseBusinessService ()
        {
            return "TestBaseBusinessService";
        }
    }
}
