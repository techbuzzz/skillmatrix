using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SkillMatrix.DomainModel.Identity
{
    public class Account: IdentityUser
    {
        public Account()
        {
            DateCreated = DateTime.Now;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public bool Activated { get; set; }

        public string Type { get; set; }

        public virtual UserProfile Profile { get; set; }

    }
}
