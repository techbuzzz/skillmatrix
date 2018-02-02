using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using SkillMatrix.Infrastructure.Base;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Infrastructure
{
    public abstract class Repository<T, TContext> : RepositoryBase<TContext>, IRepository<T>
        where T : class
        where TContext : class, IDbContext, IDisposable
    {
        protected Repository(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected ObjectContext ObjectContextWrapper => DataContext.ObjectContext;

        public virtual void Add(T entity)
        {
            Set<T>().Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Set<T>().Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            Delete((object) id);
        }

        public void Delete(string id)
        {
            Delete((object) id);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var dbSet = Set<T>();
            var objects = dbSet.Where(where).AsEnumerable();

            foreach (var obj in objects)
                dbSet.Remove(obj);
        }


        public T GetById(int id)
        {
            return Set<T>().Find(id);
        }


        public T GetById(string id)
        {
            return Set<T>().Find(id);
        }


        public T Get(Expression<Func<T, bool>> where)
        {
            return Set<T>().FirstOrDefault(where);
        }

        public IQueryable<T> GetAll()
        {
            return Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> where)
        {
            return Set<T>().Where(where);
        }

        protected IDbSet<T> Set<T>() where T : class
        {
            return DataContext.Set<T>();
        }

        //public bool Update<T>(T item, params string[] changedPropertyNames) where T
        //    : class, new()
        //{
        //    _context.Set<T>().Attach(item);
        //    foreach (var propertyName in changedPropertyNames)
        //    {
        //        // If we can't find the property, this line wil throw an exception, 
        //        //which is good as we want to know about it
        //        _context.Entry(item).Property(propertyName).IsModified = true;
        //    }
        //    return true;
        //}

        private void Delete(object id)
        {
            var dbSet = Set<T>();
            var item = dbSet.Find(id);
            dbSet.Remove(item);
        }
    }
}