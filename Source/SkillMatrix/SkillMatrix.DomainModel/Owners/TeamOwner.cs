using SkillMatrix.DomainModel.Organisation;

namespace SkillMatrix.DomainModel.Owners
{
    public class TeamOwner: Owner
    {
        public string TeamId { get; set; }

        public virtual Team Team { get; set; }

    }
}
