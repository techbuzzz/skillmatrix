using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.DomainModel.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            UId = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        
        [Column(Order = 2)]
        [Key]
        public string UId { get; set; }

        [Column(Order = 100)]
        public string CreatedById { get; set; }

        [Column(Order = 103)]
        public DateTime? CreatedOn { get; set; }

        [Column(Order = 104)]
        public string UpdatedById { get; set; }

        [Column(Order = 106)]
        public DateTime? UpdatedOn { get; set; }

        public virtual Account CreatedBy { get; set; }

    }
}
