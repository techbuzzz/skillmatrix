using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Owners
{
    public abstract class Owner: BaseEntity
    {
        public string AccountId { get; set; }
    }
}
