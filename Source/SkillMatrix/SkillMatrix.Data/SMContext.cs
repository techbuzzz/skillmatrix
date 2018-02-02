using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SkillMatrix.DomainModel.Identity;
using SkillMatrix.Infrastructure.Interfaces;

namespace SkillMatrix.Data
{
    public class SMContext : IdentityDbContext<Account>, IDbContext
    {
        public SMContext() : base("SkillMatrixConnection")
        {
            
        }
    }
}
