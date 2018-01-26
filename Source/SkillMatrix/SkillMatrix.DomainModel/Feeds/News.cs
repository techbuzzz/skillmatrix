using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Feeds
{
    public abstract class News : BaseEntity
    {
        public bool IsHighPriority { get; set; }

        public string LinkItemId { get; set; }

        public bool NeedNotify { get; set; }

        public bool? IsSentMessage { get; set; }

    }
}
