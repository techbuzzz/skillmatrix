using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Organisation
{
    public abstract class Owner: BaseEntity
    {
        public string AccountId { get; set; }
    }
}
