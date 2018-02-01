using System.ComponentModel.DataAnnotations.Schema;

namespace SkillMatrix.DomainModel.Base
{
    public class BaseItem : BaseEntity
    {
        [Column(Order = 3)]
        public string Title { get; set; }

        [Column(Order = 4)]
        public string Description { get; set; }

    }
}
