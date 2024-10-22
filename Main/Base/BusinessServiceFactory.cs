using Main.BusinessServices;

namespace Main.Base
{
    public interface IBusinessServicesFactory
    {
        public ItemService Item { get; }
    }

    public class BusinessServicesFactory : IBusinessServicesFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, object> _cacheServiceInstances = new Dictionary<Type, object>();

        public BusinessServicesFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Configure business services:
        public ItemService Item => GetBusinessService<ItemService>();



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
                // check constructor with 1 parameter with "IServiceProvider" type
                var parameters = constructor.GetParameters();
                if (parameters.Length != 1) continue;
                var param = parameters[0];
                if (param.ParameterType != typeof(IServiceProvider)) continue;

                var arguments = new object[1] { _serviceProvider };
                return (T)constructor.Invoke(arguments);
            }
            throw new InvalidOperationException($"Unable to create an instance of {type}. No suitable constructor found.");
        }
    }
}


