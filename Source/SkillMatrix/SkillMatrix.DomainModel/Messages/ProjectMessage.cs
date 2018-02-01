using SkillMatrix.DomainModel.Identity;
using SkillMatrix.DomainModel.Projects;

namespace SkillMatrix.DomainModel.Messages
{
    public class ProjectMessage : Message
    {
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }

    }
}