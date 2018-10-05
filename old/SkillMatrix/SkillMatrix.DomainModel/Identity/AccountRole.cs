using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SkillMatrix.Common.Enums;

namespace SkillMatrix.DomainModel.Identity
{
    public class AccountRole : IdentityRole<string, AccountUserRole>
    {
        public AccountRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public AccountRole(string name)
            : this()
        {
            Name = name;
        }

        public AccountRole(string name, string description)
            : this(name)
        {
            RoleDescription = description;
        }

        //public DateTime LastModified { get; set; }
        public string InternalName { get; set; }
        public RoleType RoleType { get; set; }
        public string RoleDescription { get; set; }
        public string MappedToId { get; set; }

        public virtual ICollection<AccountPemission> Permissions { get; set; }
	    public bool IsFullControl { get; set; }

	    public bool IsPermissionInRole(string permission)
        {
            var retVal = false;
            try
            {
                if (Permissions.Any(perm => perm.Name == permission))
                {
                    retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return retVal;
        }


        public bool IsPermissionInRole(PermissionType permission)
        {
            var retVal = false;
            try
            {
                if (Permissions.Any(perm => (int)perm.Type == (int)permission))
                {
                    retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return retVal;
        }

        public bool IsRoleHaveThisMapping(string mappedWith)    
        {
            var retVal = false;
            try
            {
                if (MappedToId.ToLower().Contains(mappedWith.ToLower()))
                {
                    retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return retVal;
        }
    }
}