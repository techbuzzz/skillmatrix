using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SkillMatrix.DomainModel.Identity;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Data.Contexts
{
	public class SKMContext: IdentityDbContext <Account, AccountRole, string, IdentityUserLogin, AccountUserRole, IdentityUserClaim>, IDbContext
	{
		public SKMContext() : base("MainConnection")
		{
		   
        }
		public DbSet<AccountPemission> AccountPemissions { get; set; }
	}
}
