using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillMatrix.Data.Contexts;
using SkillMatrix.DomainModel.Skills;
using SkillMatrix.Infrastructure;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Repository
{
    public interface ISkillRepository
    {
    }

    public class SkillRepository:Repository<Skill, SKMContext>, ISkillRepository
    {
        public SkillRepository(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }
    }

    
}
