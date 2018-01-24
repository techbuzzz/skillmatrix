using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SkillMatrix.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Delete(string id);
        void Delete(Expression<Func<T, bool>> where);


        T GetById(int id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> where);
    }
}