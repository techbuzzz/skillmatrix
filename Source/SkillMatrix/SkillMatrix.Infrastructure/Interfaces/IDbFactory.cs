using System;

namespace SkillMatrix.Infrastructure.Interfaces
{
    public interface IDbFactory<out TContext> : IDisposable where TContext : IDisposable
    {
        TContext GetContext();
    }
}