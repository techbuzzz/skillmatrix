using System;
using System.Configuration;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Web.Mvc;
using SkillMatrix.Common.Constants;
using SkillMatrix.Data.Configurations.Identity;
using SkillMatrix.DomainModel.Identity;
using SkillMatrix.ViewModel;
using SkillMatrix.Web.Core;
using SkillMatrix.Web.Models;

namespace SkillMatrix.Web.Controllers
{
    public class BaseController : Controller
    {

        protected void AddCreatorInformation(BaseViewModel vm)
        {
            vm.CreatedById = CurrentUser.Id;
        }

        protected void AddEditorInformation(BaseViewModel vm)
        {
            vm.UpdatedById = CurrentUser.Id;
            vm.UpdatedOn = DateTime.UtcNow;
        }

        protected new RedirectToRouteResult RedirectToAction(string actionName)
        {
            TempData["IsRedirect"] = true;
            return base.RedirectToAction(actionName);
        }

        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName,
            RouteValueDictionary routeValues)
        {
            TempData["IsRedirect"] = true;
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }

        protected override RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName,
            RouteValueDictionary routeValues)
        {
            TempData["IsRedirect"] = true;
            return base.RedirectToActionPermanent(actionName, controllerName, routeValues);
        }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }

        public ActionResult GoToReferrer()
        {
            return Request.UrlReferrer != null
                ? Redirect(Request.UrlReferrer.AbsoluteUri)
                : RedirectToAction<HomeController>(c => c.Index());
        }

        #region UserManager

        private AccountSignInManager _signInManager;
        private AccountManager _userManager;
        private AccountRoleManager _roleManager;
        //internal ProfileBaseViewModel CurrentUserProfile;
        internal AccountBaseViewModel CurrentAppUser;

        internal void InitRolesAndPermission(HttpContext context, string userId)
        {
            //if (!context.Application.AllKeys.Contains(Global.GlobalConsts.IdToRoleContextKey) ||
            //    !context.Application.AllKeys.Contains(Global.GlobalConsts.IdToPermissionContextKey))
            //{
            var user = CurrentUser ?? UserManager.FindById(userId);
            if (user != null)
            {
                var isExpired = false;
                if (context.Session[Global.GlobalConsts.ExpirationField] != null)
                {
                    var currentStamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                    var keyExpirationValue = context.Session[Global.GlobalConsts.ExpirationField];
                    int expirationValue;
                    if (int.TryParse(keyExpirationValue.ToString(), out expirationValue))
                    {
#if !DEBUG
                        isExpired = currentStamp > expirationValue;
#endif
#if DEBUG
                        isExpired = true;
#endif
                    }
                }
                else
                {
#if DEBUG
                    context.Session[Global.GlobalConsts.ExpirationField] =
                        DateTimeOffset.Now.AddMinutes(1).ToUnixTimeSeconds();

#endif
#if !DEBUG

                    context.Session[Global.GlobalConsts.ExpirationField] =
DateTimeOffset.Now.AddMinutes(10).ToUnixTimeSeconds();
#endif

                    isExpired = true;
                }
                if (isExpired)
                    PermissionHelper.InitUserPermission(context, user);

                //var permissions = new List<ApplicationPemission>();
                //foreach (var role in user.Roles.Select(c => c.Role))
                //{
                //    permissions.AddRange(role.Permissions);
                //}
                ////var permissions = user.Roles.Select(c => new List<ApplicationPemission>() { c.Role.Permissions.Select(p => p).ToList()).ToList()}
                //var idToRole = user.Roles.ToDictionary(p => p.RoleId.ToString(), p => p.Role.Name);
                //var idToPermission = permissions.ToDictionary(p => p.PermissionId.ToString(), p => p.Name);

                //context.Application[Global.GlobalConsts.IdToRoleContextKey] = idToRole;
                //context.Application[Global.GlobalConsts.IdToPermissionContextKey] = idToPermission;
            }
            //}
        }

        public AccountBaseViewModel CurrentAppProfile
        {
            get { return CurrentAppUser ?? (AccountBaseViewModel) HttpContext.Session[Global.GlobalConsts.AppUser]; }
            set { CurrentAppUser = value; }
        }

        public AccountSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<AccountSignInManager>(); }
            private set { _signInManager = value; }
        }

        public AccountManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AccountManager>(); }
            private set { _userManager = value; }
        }

        public AccountRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<AccountRoleManager>(); }
            private set { _roleManager = value; }
        }

        protected bool UserIsAuthenticated => System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

        protected Account CurrentUser
            => HttpContext.GetOwinContext()
                .GetUserManager<AccountManager>()
                .FindById(User.Identity.GetUserId());

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }
                GC.SuppressFinalize(this);
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        internal const string XsrfKey = "XsrfId";

        internal IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        internal void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error);
        }

        internal ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties {RedirectUri = RedirectUri};
                if (UserId != null)
                    properties.Dictionary[XsrfKey] = UserId;
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        internal bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user?.PasswordHash != null;
        }

        internal bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user?.PhoneNumber != null;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion

        #endregion
    }
}