using System;

namespace DeviceManager.Api.Data.Management
{
    /// <summary>
    /// Contains functions to manipulate EF transactions
    /// </summary>
    public interface IUnitOfWork 
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;
    }
}