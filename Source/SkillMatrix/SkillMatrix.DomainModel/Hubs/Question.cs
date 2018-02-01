using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Hubs
{
    public class Question: BaseItem
    {
        public string HubId { get; set; }
        public bool IsResolved { get; set; }

        public virtual Hub Hub { get; set; }


    }
}
