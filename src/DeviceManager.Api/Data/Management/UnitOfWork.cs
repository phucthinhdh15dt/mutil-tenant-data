using System;
using System.Collections.Generic;

namespace DeviceManager.Api.Data.Management
{
   
    public sealed class UnitOfWork : IUnitOfWork
    {
     
        private IDbContext dbContext;
        private Dictionary<Type, object> repositories;
        public UnitOfWork(IContextFactory contextFactory)
        {
            this.dbContext = contextFactory.DbContext;
        }
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<Type, object>();
            }
            var type = typeof(TEntity);
            if (!this.repositories.ContainsKey(type))
            {
                this.repositories[type] = new Repository<TEntity>(this.dbContext);
            }
            return (IRepository<TEntity>)this.repositories[type];
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        //public int Commit()
        //{
        //    // Save changes with the default options
        //    return this.dbContext.SaveChanges();
        //}

        /// <summary>
        /// Disposes the current object
        /// </summary>
        //public void Dispose()
        //{
        //    this.Dispose(true);

        //    // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
        //    GC.SuppressFinalize(obj: this);
        //}

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        //private void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (this.dbContext != null)
        //        {
        //            this.dbContext.Dispose();
        //            this.dbContext = null;
        //        }
        //    }
        //}
    }
}
