using Main.DataAccess.AppDbContext;
using Main.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Main.Base
{
    public interface IUnitOfWork : IDisposable
    {
        // config repository
        public ItemRepository Item { get; }

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
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // config repository
        public ItemRepository Item => new(_dbContext);


        // for IDisposable implementation
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _transaction?.Dispose();
                }
            }
            this.disposed = true;
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
