using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter);
    }
}
