using System;
using Microsoft.AspNet.Identity.EntityFramework;
using SkillMatrix.Common.Enums;

namespace SkillMatrix.DomainModel.Identity
{
    public class AccountUserRole : IdentityUserRole<string>
    {
        public AccountUserRole()
            : base()
        {
        }

        public virtual AccountRole Role { get; set; }
        //public ApplicationUser User { get; set; }

        public bool IsPermissionInRole(string permission)
        {
            var retVal = false;
            try
            {
                retVal = Role.IsPermissionInRole(permission);
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
                retVal = Role.IsPermissionInRole(permission);
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
                retVal = Role.IsRoleHaveThisMapping(mappedWith);
            }
            catch (Exception)
            {
            }
            return retVal;
        }


        public bool IsFullControl => Role.RoleType == RoleType.Administrator;

    }
}
