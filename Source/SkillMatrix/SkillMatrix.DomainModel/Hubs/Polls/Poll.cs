using System;
using System.Collections.Generic;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Hubs.Polls
{
    public partial class Poll : BaseEntity
    {
       
        public bool IsClosed { get; set; }
        public int? ClosePollAfterDays { get; set; }

        public virtual IList<PollAnswer> PollAnswers { get; set; } 
    }
}
