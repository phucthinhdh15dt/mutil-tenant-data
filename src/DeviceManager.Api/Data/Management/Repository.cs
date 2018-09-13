using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Api.Data.Management
{
    /// <summary>
    /// Generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly IDbContext context;

        private readonly DbSet<T> dbSet;

       
        public Repository(IDbContext context)
        {
            this.context = context;

            this.dbSet = context.Set<T>();
        }

      
        public virtual EntityState Add(T entity)
        {
            return this.dbSet.Add(entity).State;
        }

       
        public T Get<TKey>(TKey id)
        {
            return this.dbSet.Find(id);
        }

        
        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        
        public T Get(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

       
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            return this.FindBy(predicate).Include(include);
        }

       
        public IQueryable<T> GetAll()
        {
            return this.dbSet;
        }

        public IQueryable<T> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;

            return this.dbSet.Skip(pageSize).Take(pageCount);
        }

       
        public IQueryable<T> GetAll(string include)
        {
            return this.dbSet.Include(include);
        }

       
        public IQueryable<T> FromSql(string query, params object[] parameters)
        {
            return this.dbSet.FromSql(query, parameters);
        }

        
        public IQueryable<T> GetAll(string include, string include2)
        {
            return this.dbSet.Include(include).Include(include2);
        }

      
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Any(predicate);
        }

       
        public EntityState Delete(T entity)
        {
            return this.dbSet.Remove(entity).State;
        }

        /// <inheritdoc />
        public virtual EntityState Update(T entity)
        {
            return this.dbSet.Update(entity).State;
        }

     
    }
}
