using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
     public class GenericRepository<T> :UnitOfWork, IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;


        public GenericRepository(DataContext context):base(context)
        {
            _context = context;


    }

    public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
 
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Find(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void InsertRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
   
        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var entity = Find(id);
            // if entity exists
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }
        public void Delete(Guid id)
        {
            var entity = Find(id);
            // if entity exists
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public void DeleteRate(T entity)
        {
            // if entity exists
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }
     
    }
}
