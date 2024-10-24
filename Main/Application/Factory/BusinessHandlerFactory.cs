using Main.Application.DendencyInjection;
using Main.BusinessHandler;

namespace Main.Application.Factory
{
    public interface IBusinessHandlersFactory : IBaseFactoryImplementation
    {
        public IItemBusinessHandler Item { get; }
    }

    public class BusinessHandlersFactory : BaseFactoryImplementation<IBusinessHandlerDependencies>, IBusinessHandlersFactory
    {
        public BusinessHandlersFactory(IBusinessHandlerDependencies businessHandlerDependencies) : base(businessHandlerDependencies)
        {
        }

        #region ----------> Configure business services:
        public IItemBusinessHandler Item => GetInstance<ItemBusinessHandler>();

        #endregion
    }
}


