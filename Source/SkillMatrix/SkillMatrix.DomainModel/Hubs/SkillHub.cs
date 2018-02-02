using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;
using SkillMatrix.DomainModel.Skills;

namespace SkillMatrix.DomainModel.Hubs
{
    public class SkillHub : Hub
    {
        public string SkillId { get; set; }
        public virtual Skill Skill { get; set; }

    }
}
