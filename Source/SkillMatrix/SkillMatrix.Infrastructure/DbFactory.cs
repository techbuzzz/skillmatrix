using System;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Infrastructure
{
    public class DbFactory<TContext> : IDbFactory<TContext> where TContext : class, IDbContext, IDisposable, new()
    {
       
        private TContext _dataContext;

        public TContext GetContext()
        {
            return _dataContext ?? (_dataContext = new TContext());
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}