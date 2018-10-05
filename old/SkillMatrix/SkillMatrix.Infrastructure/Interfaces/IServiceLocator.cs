using System;
using System.Collections.Generic;

namespace SkillMatrix.Infrastructure.Interfaces
{
    public interface IServiceLocator
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}