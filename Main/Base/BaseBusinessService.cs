namespace Main.Base
{
    public abstract class BaseBusinessService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseBusinessService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
