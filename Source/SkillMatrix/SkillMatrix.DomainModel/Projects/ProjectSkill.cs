using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;
using SkillMatrix.DomainModel.Skills;

namespace SkillMatrix.DomainModel.Projects
{
    public class ProjectSkill: BaseEntity
    {
        public string ProjectId { get; set; }
        public string SkillId { get; set; }


        public virtual Project Project { get; set; }

        public virtual Skill Skill { get; set; }



    }
}
