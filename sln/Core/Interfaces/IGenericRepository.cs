using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
    public    Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<T> FindAsync(int id);
        T Find(int id);
        IQueryable<T> Query();
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(int id);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<T> entity);
        void DeleteRate(T entity);


    }
}
