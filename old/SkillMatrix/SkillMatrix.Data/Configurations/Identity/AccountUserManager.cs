using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SkillMatrix.Data.Contexts;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.Data.Configurations.Identity
{

    public class AccountStore : UserStore<Account, AccountRole, string, IdentityUserLogin, AccountUserRole, IdentityUserClaim>, IUserStore<Account, string>
    {
        public AccountStore(SKMContext context)
            : base(context)
        {
        }
    }

    public class AccountManager : UserManager<Account, string>
    {
        public AccountManager(IUserStore<Account, string> store)
            : base(store)
        {
        }

        public static AccountManager Create(IdentityFactoryOptions<AccountManager> options, IOwinContext context)
        {
            _context = context;
            var manager = new AccountManager(new AccountStore(context.Get<SKMContext>()));
            //Manager = manager;
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Account>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Account>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Account>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Account>(dataProtectionProvider.Create("Abiroy TMS"))
                    {
                        TokenLifespan = TimeSpan.FromDays(12)
                    };
            }
            return manager;
        }

        private static AccountManager _userManager;
        private static IOwinContext _context;

        public static AccountManager UserManager
        {
            get { return _context.GetUserManager<AccountManager>(); }
            private set { _userManager = value; }
        }
        //public static AccountManager Manager { get; set; }

        public static Account GetUser(string userId)
        {
            Account user = null;
            try
            {
                user = UserManager.Users.Include(c => c.Roles).FirstOrDefault(c => c.Id == userId);

            }
            catch (Exception ex)
            {
                try
                {
                    if (_context != null)
                    {
                        using (var store = new AccountStore(_context.Get<SKMContext>()))
                        { 
                            using (var manager = new AccountManager(store))
                            {
                                user = manager.Users.Include(c => c.Roles).FirstOrDefault(c => c.Id == userId);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        using (var db = new SKMContext())
                        {
                            return GetUserWithContext(db, userId);
                        }
                    }
                    catch (Exception exception)
                    {
                        // log exception
                        return user;
                    }


                }

            }
            return user;
            //var roles = UserManager.GetRoles(userId);

        }

        //public static Account GetUser(string _userId)
        //{
        //    using (TMSContext db = new TMSContext())
        //    {
        //        return GetUser(db, _userId);
        //    }
        //}

        public static Account GetUserWithContext(SKMContext db, string userId)
        {
            Account retVal = null;
            try
            {
                retVal = db.Users.Where(p => p.Id == userId).Include(c => c.Roles).Include(x => x.Roles.Select(r => r.Role.Permissions)).FirstOrDefault();
            }
            catch (Exception)
            {
            }

            return retVal;
        }

        public static bool AddUserToRole(string userId, string roleId)
        {
            var retVal = false;
            try
            {

                var user = GetUser(userId);
                if (user != null)
                {
                    if (user.Roles.All(p => p.RoleId != roleId))
                    {
                        var identityRole = new AccountUserRole { UserId = userId, RoleId = roleId };
                        if (!user.Roles.Contains(identityRole))
                            user.Roles.Add(identityRole);
                        user.LastModified = DateTime.Now;
                        if (UserManager != null)
                        {
                            UserManager.Update(user);

                        }
                        else
                        {
                            if (_context != null)
                            {
                                using (var manager =
                                    new AccountManager(new AccountStore(_context.Get<SKMContext>())))
                                {
                                    manager.Update(user);
                                }
                            }
                            else
                            {
                                using (var db = new SKMContext())
                                {
                                    using (var manager = new AccountManager(new AccountStore(db)))
                                    {
                                        manager.Update(user);
                                    }
                                }
                            }

                        }
                        retVal = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return retVal;
        }


        public static bool RemoveUserFromRole(string userId, string roleId)
        {
            var retVal = false;
            try
            {
                var user = GetUser(userId);
                if (user != null)
                {
                    if (user.Roles.Any(p => p.RoleId == roleId))
                    {
                        user.Roles.Remove(user.Roles.FirstOrDefault(p => p.RoleId == roleId));
                        if (UserManager != null)
                        {
                            UserManager.Update(user);
                        }
                        else
                        {
                            if (_context != null)
                            {
                                using (var manager = new AccountManager(new AccountStore(_context.Get<SKMContext>())))
                                {
                                    manager.Update(user);
                                }
                            }
                            else
                            {
                                using (var db = new SKMContext())
                                {
                                    using (var manager = new AccountManager(new AccountStore(db)))
                                    {
                                        manager.Update(user);
                                    }
                                }
                            }
                        }
                        retVal = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return retVal;
        }
    }
}
