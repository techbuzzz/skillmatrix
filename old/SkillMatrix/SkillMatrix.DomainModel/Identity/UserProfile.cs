using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;
using SkillMatrix.DomainModel.Identity.Relation;

namespace SkillMatrix.DomainModel.Identity
{
    public class UserProfile: BaseEntity
    {
        public string AccountId { get; set; }

        public string CompanyId { get; set; }

        public virtual ICollection<DepartmentRelation> Departments { get; set; }
        public virtual ICollection<TeamRelation> Teams { get; set; }
        public virtual ICollection<ProjectRelation> Projects { get; set; }


    }
}
