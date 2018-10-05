using System;
using System.Threading.Tasks;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Infrastructure.Base
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWork where TContext : class, IDisposable
    {
        private readonly IServiceLocator _serviceLocator;

        protected UnitOfWorkBase(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        protected TContext DataContext
        {
            get
            {
                var contextFactory = (IDbFactory<TContext>) _serviceLocator.GetService(typeof(IDbFactory<TContext>));
                return contextFactory.GetContext();
            }
        }


        public abstract void Commit();
        public abstract Task CommitAsync();


        public abstract Task<int> CommitAsyncWithStatus();


        //public void Commit()
        //{
        //    DbContext.Commit();
        //}

        //public async Task CommitAsync()
        //{
        //   await DbContext.CommitAsync();
        //}

        //public async Task<int> CommitAsyncWithStatus()
        //{
        //   return await DbContext.CommitAsyncWithStatus();
        //}
    }
}