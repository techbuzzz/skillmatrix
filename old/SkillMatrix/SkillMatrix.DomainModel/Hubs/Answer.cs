using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Hubs
{
    public class Answer: BaseEntity
    {
        public string QuestionId { get; set; }

        public string Content { get; set; }

        public int VoteCount { get; set; }

        public bool IsSolution { get; set; }

        public virtual Question Question { get; set; }

    }
}
