using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T>where T:class
    {
        Context context = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public void Add(T t)
        {
            var addedEntity = context.Entry(t);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            var deletedEntity = context.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = context.Entry(t);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
