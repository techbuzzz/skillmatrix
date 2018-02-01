using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.DomainModel.Messages
{
    public class PrivateMessage : Message
    {
        public bool IsRead { get; set; }
        public string AccountToId { get; set; }


        public virtual Account AccountTo { get; set; }
    }
}