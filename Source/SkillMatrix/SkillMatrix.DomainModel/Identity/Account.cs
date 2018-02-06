using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SkillMatrix.Common.Enums;

namespace SkillMatrix.DomainModel.Identity
{
	/// <inheritdoc />
	public class Account: IdentityUser<string, IdentityUserLogin, AccountUserRole, IdentityUserClaim>
	{
        public Account()
        {
            DateCreated = DateTime.Now;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginTime { get; set; }

		public DateTime? LastModified { get; set; }


		public bool Activated { get; set; }

        public string Type { get; set; }

        public virtual UserProfile Profile { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account, string> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

		public bool IsPermissionInUserRoles(string permission)
		{
			var retVal = false;
			try
			{
				if (this.Roles.Any(role => role.IsPermissionInRole(permission)))
				{
					retVal = true;
				}
			}
			catch (Exception)
			{
			}
			return retVal;
		}

		public bool IsPermissionInUserRoles(PermissionType permission)
		{
			var retVal = false;
			try
			{
				if (Roles.Any(role => role.IsPermissionInRole(permission)))
				{
					retVal = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return retVal;
		}

		public bool IsPermissionInUserRolesAndCheckMapping(PermissionType permission, string mappedWith)
		{
			var retVal = false;
			try
			{
				var userHaveFullControl = Roles.Any(role => role.IsFullControl);
				if (!userHaveFullControl)
				{
					var userHaveMappingForThis = Roles.Any(role => role.IsRoleHaveThisMapping(mappedWith));
					if (userHaveMappingForThis)
					{

						if (Roles.Any(role => role.IsPermissionInRole(permission)))
						{
							retVal = true;
						}
					}
				}
				else
				{
					retVal = true;
				}

			}
			catch (Exception)
			{
				throw;

			}
			return retVal;


		}

	}
}
