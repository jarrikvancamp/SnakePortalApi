using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    /// <summary>
    ///     This is a generic Repository that works with any type of entity. This code was inspired by the code created by the
    ///     people of 6figuredev.com
    ///     See <a href="http://6figuredev.com/technology/generic-repository-dependency-injection-with-net-core/">Here</a>
    ///     Part of the other methods where inspired by
    ///     <a
    ///         href="http://www.itworld.com/article/2700950/development/a-generic-repository-for--net-entity-framework-6-with-async-operations.html">
    ///         this
    ///     </a>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        void Add(T entity);
        Task<T> AddAsync(T entity);
        int Count();
        Task<int> CountAsync();
        void Delete(T t);
        Task<int> DeleteAsync(T t);
        bool EnsureCreated(bool forceCreate = false);
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        T Get<TKey>(TKey id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        T Update(T updated, int key);
        Task<T> UpdateAsync(T updated, int key);
    }
}