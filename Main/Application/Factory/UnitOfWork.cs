using Main.Application.DendencyInjection;
using Main.Infrastructure.AppDbContext;
using Main.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Main.Application.Factory
{
    public interface IUnitOfWork : IDisposable, IBaseFactoryImplementation
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

    public class UnitOfWork : BaseFactoryImplementation<IRepositoryDependencies>, IUnitOfWork
    {
        private readonly IApplicationDbContext _applicationDbcontext;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(IRepositoryDependencies repositoryDependencies) : base(repositoryDependencies)
        {
            _applicationDbcontext = repositoryDependencies.ApplicationDbContext;
        }

        #region ----------> Config Repository
        public IItemRepository Item => GetInstance<ItemRepository>();

        #endregion


        #region ----------> UnitOfWork Processing

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _applicationDbcontext.Dispose();
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
            _applicationDbcontext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _applicationDbcontext.SaveChangesAsync();
        }
        public void BeginTransaction<TContext>() where TContext : DbContext
        {
            if (typeof(TContext) == typeof(ApplicationDbContext))
                _transaction = _applicationDbcontext.Database.BeginTransaction();
        }
        public void CommitTransaction<TContext>() where TContext : DbContext => _transaction?.Commit();
        public void RollbackTransaction<TContext>() where TContext : DbContext => _transaction?.Rollback();

        #endregion
    }
}
