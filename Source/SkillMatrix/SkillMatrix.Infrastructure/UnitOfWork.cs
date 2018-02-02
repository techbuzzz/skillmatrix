using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using SkillMatrix.Infrastructure.Base;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Infrastructure
{
    public class UnitOfWork<TContext> : UnitOfWorkBase<TContext>
        where TContext : class, IDisposable, IObjectContextAdapter
    {
        public UnitOfWork(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected ObjectContext ObjectContext => DataContext.ObjectContext;

        protected ObjectStateManager ObjectStateManager => ObjectContext.ObjectStateManager;

        public override void Commit()
        {
            var dbContext = DataContext as DbContext;
            dbContext?.SaveChanges();
        }

        public override async Task CommitAsync()
        {
            var dbContext = DataContext as DbContext;

            await dbContext?.SaveChangesAsync();
        }

        public override async Task<int> CommitAsyncWithStatus()
        {
            var dbContext = DataContext as DbContext;

            return await dbContext?.SaveChangesAsync();
        }
    }
}