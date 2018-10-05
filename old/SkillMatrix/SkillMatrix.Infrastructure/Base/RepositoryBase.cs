using System;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Infrastructure.Base
{
    public abstract class RepositoryBase<TContext> where TContext : class, IDisposable
    {
        private readonly IServiceLocator _serviceLocator;

        protected RepositoryBase(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        protected internal TContext DataContext =>
            ((IDbFactory<TContext>) _serviceLocator.GetService(typeof(IDbFactory<TContext>))).GetContext();
    }
}