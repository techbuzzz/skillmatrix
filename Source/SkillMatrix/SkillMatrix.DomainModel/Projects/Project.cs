using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;
using SkillMatrix.DomainModel.Hubs;

namespace SkillMatrix.DomainModel.Projects
{
    public class Project : BaseItem
    {
        public string HubId { get; set; }


        public virtual Hub Hub { get; set; }

    }
}
