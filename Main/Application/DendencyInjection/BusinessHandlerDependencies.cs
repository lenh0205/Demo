using Main.Application.Factory;

namespace Main.Application.DendencyInjection
{
    public interface IBusinessHandlerDependencies
    {
        public IUnitOfWork UnitOfWork { get; }
    }

    public class BusinessHandlerDependencies : IBusinessHandlerDependencies
    {
        public IUnitOfWork UnitOfWork { get; }
        public BusinessHandlerDependencies(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
