using Main.DataAccess.AppDbContext;
using Main.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Main.Application.Factory
{
    public interface IUnitOfWork : IDisposable
    {
        // config repository
        public IItemRepository Item { get; }


        // for IDisposable implementation
        public Task CommitAsync();
        public void Commit();
        public void CommitTransaction<TContext>() where TContext : DbContext;
        public void RollbackTransaction<TContext>() where TContext : DbContext;
        public void BeginTransaction<TContext>() where TContext : DbContext;
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction? _transaction;
        private readonly Dictionary<Type, object> _cacheRepositoryInstances = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // config repository
        public IItemRepository Item => GetRepository<ItemRepository>();


        private T GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (_cacheRepositoryInstances.TryGetValue(type, out var service)) return (T)service;

            var newInstance = CreateInstance<T>();
            _cacheRepositoryInstances[type] = newInstance;
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
                if (param.ParameterType != typeof(DbContext)) continue;

                var arguments = new object[1] { _dbContext };
                return (T)constructor.Invoke(arguments);
            }
            throw new InvalidOperationException($"Unable to create an instance of {type}. No suitable constructor found.");
        }

        // for IDisposable implementation
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _transaction?.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void BeginTransaction<TContext>() where TContext : DbContext
        {
            if (typeof(TContext) == typeof(ApplicationDbContext))
                _transaction = _dbContext.Database.BeginTransaction();
        }
        public void CommitTransaction<TContext>() where TContext : DbContext => _transaction?.Commit();
        public void RollbackTransaction<TContext>() where TContext : DbContext => _transaction?.Rollback();
    }
}
