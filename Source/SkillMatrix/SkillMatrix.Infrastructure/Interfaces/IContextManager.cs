using System;

namespace SkillMatrix.Infrastructure.Interfaces
{
    public interface IContextManager : IDisposable
    {
        void Release();
    }
}
