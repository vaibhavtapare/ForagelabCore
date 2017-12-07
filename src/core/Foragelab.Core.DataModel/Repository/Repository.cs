using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foragelab.Core.DataModel.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public Repository(CVASContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }
        
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Save();
        }

        public T Get<TKey>(TKey id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query;
        }

        public void Update(T entity)
        {
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
