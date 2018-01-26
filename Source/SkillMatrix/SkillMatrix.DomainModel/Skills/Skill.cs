using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Skills
{
    public class Skill: BaseItem
    {
        public bool IsHub { get; set; }
        public string HubId { get; set; }
    }
}
