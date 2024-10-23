using Main.Application.DendencyInjection;
using Main.BusinessHandler;

namespace Main.Application.Factory
{
    public interface IBusinessHandlersFactory
    {
        public IItemBusinessHandler Item { get; }
    }

    public class BusinessHandlersFactory : IBusinessHandlersFactory
    {
        private readonly IBusinessHandlerDependencies _serviceProvider;
        private readonly Dictionary<Type, object> _cacheServiceInstances = new();

        public BusinessHandlersFactory(IBusinessHandlerDependencies serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Configure business services:
        public IItemBusinessHandler Item => GetBusinessService<ItemBusinessHandler>();


        /// <summary>
        /// Manage lifetime's instance of properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T GetBusinessService<T>() where T : class
        {
            var type = typeof(T);
            if (_cacheServiceInstances.TryGetValue(type, out var service)) return (T)service;

            var newInstance = CreateInstance<T>();
            _cacheServiceInstances[type] = newInstance;
            return newInstance;
        }
        private T CreateInstance<T>() where T : class
        {
            var type = typeof(T);
            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                // check constructor has 1 parameter with "IServiceProvider" type
                var parameters = constructor.GetParameters();
                if (parameters.Length != 1) continue;
                var param = parameters[0];
                if (param.ParameterType != typeof(IBusinessHandlerDependencies)) continue;

                var arguments = new object[1] { _serviceProvider };
                return (T)constructor.Invoke(arguments);
            }
            throw new InvalidOperationException($"Unable to create an instance of {type}. No suitable constructor found.");
        }
    }
}


