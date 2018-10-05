using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Infrastructure
{
    public class SkillMatrixServiceLocator: IServiceLocator
    {
        readonly ConcurrentDictionary<Type, object> _services;
        public SkillMatrixServiceLocator()
        {
            _services = new ConcurrentDictionary<Type, object>
            {



            };
        }
        public object GetService(Type serviceType)
        {
            return _services[serviceType];
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
