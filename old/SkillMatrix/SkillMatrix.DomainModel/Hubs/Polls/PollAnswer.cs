using System;
using System.Collections.Generic;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Hubs.Polls
{
    public partial class PollAnswer:BaseEntity
    {
        public string Answer { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual IList<PollVote> PollVotes { get; set; }
    }
}
