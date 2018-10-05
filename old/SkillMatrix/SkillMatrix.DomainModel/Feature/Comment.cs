using SkillMatrix.Common.Enums;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Feature
{
    public abstract class Comment: BaseEntity
    {
        public string ReplyId { get; set; }

        public string EntityId { get; set; }

        public CommentType Type { get; set; }

        public virtual Comment Reply { get; set; }

    }
}
