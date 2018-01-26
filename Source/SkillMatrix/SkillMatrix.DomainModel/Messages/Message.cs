using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Messages
{
    public abstract class Message: BaseEntity
    {
        public DateTime DateSent { get; set; }

        public string Content { get; set; }

        public bool NeedNotify { get; set; }
        public bool? IsSentMessage { get; set; }


    }
}
