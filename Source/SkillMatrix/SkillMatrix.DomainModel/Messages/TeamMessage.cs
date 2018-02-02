using SkillMatrix.DomainModel.Organisation;

namespace SkillMatrix.DomainModel.Messages
{
    public class TeamMessage : Message
    {
        public string TeamId { get; set; }

        public virtual Team Team { get; set; }


    }
}