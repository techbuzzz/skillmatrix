using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using SkillMatrix.Common.Enums;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        //public static string SplitViewerRole(string key)
        //{
        //    return $"{key}_{Constant.Global.Roles.Viewer}";
        //}
        //public static string SplitAdminRole(string key)
        //{
        //    return $"{key}_{Constant.Global.Roles.Administrator}";
        //}

        //public static string GetDashboardKeyFromRole(string role)
        //{
        //    return role.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
        //}

        public static bool IsSuperAdmin(IIdentity identity)
        {
            var result = false;
            var claim = ((ClaimsIdentity) identity).FindFirst("IsSuperAdmin");
            if (claim != null)
            {
                if (bool.TryParse(claim.Value, out result))
                {
                    return result;
                }
            }
            return result;
        }
    }
}