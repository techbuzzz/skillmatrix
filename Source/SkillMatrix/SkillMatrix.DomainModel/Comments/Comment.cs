using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Comments
{
    public abstract class Comment: BaseEntity
    {
        public string ReplyId { get; set; }
    }
}
