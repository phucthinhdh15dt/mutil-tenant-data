using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Api.Data
{
    /// <summary>
    /// Interface for the Device EF Context
    /// </summary>
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    }
}