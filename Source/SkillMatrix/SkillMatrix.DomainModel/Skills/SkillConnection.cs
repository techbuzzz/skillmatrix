using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Skills
{
    public class SkillConnection: BaseEntity
    {
        public string SkillId { get; set; }
        public string ConnectedSkillId { get; set; }

        public decimal RelationDistance { get; set; }

    }
}
