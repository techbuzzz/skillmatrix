using SkillMatrix.Common.Enums;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Feature
{
    public abstract class News : BaseEntity
    {
        public bool IsHighPriority { get; set; }

        public string LinkItemId { get; set; }

        public bool NeedNotify { get; set; }

        public bool? IsSentMessage { get; set; }

        public NewsType Type { get; set; }

    }
}
