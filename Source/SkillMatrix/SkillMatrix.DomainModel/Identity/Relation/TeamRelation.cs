using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DomainModel.Identity.Relation
{
    public class TeamRelation: UserRelation
    {
        public string TeamId { get; set; }
    }
}
