using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Api.Data.Management
{
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        Task<T> GetAsync<TKey>(TKey id);
        T Get(params object[] keyValues);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(int page, int pageCount);
        IQueryable<T> GetAll(string include);
        IQueryable<T> FromSql(string sql, params object[] parameters);
        IQueryable<T> GetAll(string include, string include2);
        EntityState Add(T entity);
        EntityState Delete(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);
        EntityState Update(T entity);
    }
}