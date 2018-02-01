using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DomainModel.Identity.Relation
{
    public class DepartmentRelation: UserRelation
    {
        public string DepartmentId { get; set; }
    }
}
