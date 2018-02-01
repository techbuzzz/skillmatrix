using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SkillMatrix.Common.Enums;

namespace SkillMatrix.DomainModel.Identity
{
    public class AccountPemission
    {
        public AccountPemission()
        {
            PermissionId = Guid.NewGuid().ToString();
        }

        [Key]
        public string PermissionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        //public string ProvidedById { get; set; }
        public PermissionType Type { get; set; }
        public virtual ICollection<AccountRole> Roles { get; set; }
    }
}
