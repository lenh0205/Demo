using Main.Application.Base;
using Main.Application.DendencyInjection;

namespace Main.BusinessHandler
{
    public interface IProductBusinessHandler : IBaseBusinessHandler
    {
        public string GetOne();
    }

    public class ProductBusinessHandler : BaseBusinessHandler, IProductBusinessHandler
    {
        public ProductBusinessHandler(IBusinessHandlerDependencies serviceProvider) : base(serviceProvider)
        {
        }

        public string GetOne()
        {
            var result = _mongoUnitOfWork.Product.TestProductRepository();
            return result;
        }
    }
}
