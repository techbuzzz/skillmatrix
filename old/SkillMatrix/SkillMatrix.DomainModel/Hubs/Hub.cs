using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Hubs
{
    public abstract class Hub: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
