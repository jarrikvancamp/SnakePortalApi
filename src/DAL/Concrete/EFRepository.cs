using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Abstract;
using DAL.Infrastructure;

namespace DAL.Concrete
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        #region Constructor

        public EfRepository()
        {
            _context = new EfDbContext();
            _dbSet = _context.Set<T>();
        }

        #endregion

        #region Private Members

        private readonly EfDbContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region Synchronuous Methods

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> result = _dbSet.ToList();
            return result;
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match).ToList();
        }

        public T Get<TKey>(TKey id)
        {
            return _dbSet.Find(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _dbSet.SingleOrDefault(match);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            var existing = _dbSet.Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                Save();
            }
            return existing;
        }

        public void Delete(T t)
        {
            _dbSet.Remove(t);
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public bool EnsureCreated(bool forceCreate = false)
        {
            var dbExists = _context.Database.Exists();
            if (dbExists == false && forceCreate)
                _context.Database.CreateIfNotExists();
            return dbExists;
        }

        #endregion

        #region Asynchronuous Methods

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.Where(match).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.SingleOrDefaultAsync(match);
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);

            await SaveAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T updated, int key)
        {
            if (updated == null)
                return null;

            var existing = await _dbSet.FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public async Task<int> DeleteAsync(T t)
        {
            _dbSet.Remove(t);
            return await _context.SaveChangesAsync();
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        #endregion
    }
}