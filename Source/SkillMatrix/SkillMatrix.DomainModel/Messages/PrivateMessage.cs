namespace SkillMatrix.DomainModel.Messages
{
    public class PrivateMessage : Message
    {
        public bool IsRead { get; set; }
        public string AccountToId { get; set; }
        public string AccountFromId { get; set; }
    }
}