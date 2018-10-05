using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.DomainModel.Skills
{
    public class Endorse: BaseEntity
    {
        public string SkillId { get; set; }
        public string AccountId { get; set; }
        public int Vote { get; set; }


        public virtual Account Account { get; set; }
        public virtual Skill Skill { get; set; }


    }
}
