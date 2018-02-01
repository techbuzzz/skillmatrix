using SkillMatrix.DomainModel.Skills;

namespace SkillMatrix.DomainModel.Owners
{
    public class SkillKeeper: Owner
    {
        public string SkillId { get; set; }
        public decimal Ratio { get; set; }

        public virtual Skill Skill { get; set; }

    }
}
