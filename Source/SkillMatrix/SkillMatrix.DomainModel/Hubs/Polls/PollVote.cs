using System;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Hubs.Polls
{
    public partial class PollVote:BaseEntity
    {
        public virtual PollAnswer PollAnswer { get; set; }
    }
}
