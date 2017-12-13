using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foragelab.Core.DataModel.Repository
{
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);      
        Task<T> FindAsync(Expression<Func<T, bool>> match);
    }
}
