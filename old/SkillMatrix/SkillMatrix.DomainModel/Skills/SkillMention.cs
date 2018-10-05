using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Skills
{
    public class SkillMention: BaseEntity
    {
        public string SkillId { get; set; }

        public string LinkItemId { get; set; }

        public virtual Skill Skill { get; set; }

    }
}
