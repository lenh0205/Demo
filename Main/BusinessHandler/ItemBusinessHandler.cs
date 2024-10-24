using Main.Application.Base;
using Main.Application.DendencyInjection;

namespace Main.BusinessHandler
{
    public interface IItemBusinessHandler : IBaseBusinessHandler
    {
        public string GetOne();
    }

    public class ItemBusinessHandler : BaseBusinessHandler, IItemBusinessHandler
    {
        public ItemBusinessHandler(IBusinessHandlerDependencies serviceProvider) : base(serviceProvider)
        {
        }

        public string GetOne()
        {
            var result = _unitOfWork.Item.TestItemRepository();
            return result;
        }
    }
}
