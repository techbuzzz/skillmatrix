using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.Data.Configurations.Identity
{
    public class AccountSignInManager : SignInManager<Account, string>
    {
        public AccountSignInManager(AccountManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(Account user)
        {
            return user.GenerateUserIdentityAsync(UserManager);
        }

        public static AccountSignInManager Create(IdentityFactoryOptions<AccountSignInManager> options, IOwinContext context)
        {
            return new AccountSignInManager(context.GetUserManager<AccountManager>(), context.Authentication);
        }
    }
}
