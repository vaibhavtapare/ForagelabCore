﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foragelab.Core.DataModel.Repository
{
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
    }
}
