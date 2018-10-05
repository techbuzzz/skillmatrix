using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DomainModel.Identity.Relation
{
    public class ProjectRelation: UserRelation
    {
        public string ProjectId { get; set; }
    }
}
