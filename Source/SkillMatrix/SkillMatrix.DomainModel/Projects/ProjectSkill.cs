using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Projects
{
    public class ProjectSkill: BaseEntity
    {
        public string ProjectId { get; set; }
        public string SkillId { get; set; }

    }
}
