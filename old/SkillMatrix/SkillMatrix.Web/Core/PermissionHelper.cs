using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkillMatrix.Common.Constants;
using SkillMatrix.Common.Enums;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.Web.Core
{
    public class PermissionHelper
    {
        public static void InitUserPermission(HttpContext ctx, Account user)
        {
            
            //if (ctx.Session[Global.GlobalConsts.IdToRoleContextKey] != null ||
            //    ctx.Session[Global.GlobalConsts.RoleToIdContextKey] != null ||
            //    ctx.Session[Global.GlobalConsts.IdToPermissionContextKey] != null ||
            //    ctx.Session[Global.GlobalConsts.PermissionToIdContextKey] != null ||
            //    ctx.Session[Global.GlobalConsts.RoleIdToMappedContextKey] != null) return;


            var permissions = new HashSet<AccountPemission>();

            foreach (var role in user.Roles.Select(c => c.Role))
            {
                foreach (var applicationPemission in role.Permissions)
                {
                    permissions.Add(applicationPemission);
                }
            }

            var idToRole = user.Roles.ToDictionary(p => p.RoleId.ToString(), p => p.Role.Name);
            var roleToId = user.Roles.ToDictionary(p => p.Role.Name, p => p.Role.Id.ToString());
            var roleToMapping = user.Roles.ToDictionary(p => p.RoleId.ToString(), p => p.Role.MappedToId?? string.Empty);
            var idToPermission = permissions.ToDictionary(p => p.PermissionId.ToString(), p => p.Name);
            var permissionToId = permissions.ToDictionary(p => p.Name.ToString(), p => p.PermissionId);
            var permissionTypeToName = permissions.ToDictionary(p => p.Type, p => p.Name);



            ctx.Session[Global.GlobalConsts.IdToRoleContextKey] = idToRole;
            ctx.Session[Global.GlobalConsts.RoleToIdContextKey] = roleToId;

            ctx.Session[Global.GlobalConsts.IdToPermissionContextKey] = idToPermission;
            ctx.Session[Global.GlobalConsts.PermissionToIdContextKey] = permissionToId;
            ctx.Session[Global.GlobalConsts.PermissionTypeToNameContextKey] = permissionTypeToName;


            ctx.Session[Global.GlobalConsts.RoleIdToMappedContextKey] = roleToMapping;


        }

        public static bool DoesUserHavePermission()
        {
            return false;
        }

        public static bool CanSee(params PermissionType[] permissions)
        {
            var canSee = false;
            var context = HttpContext.Current;
            if (context.Session[Global.GlobalConsts.PermissionTypeToNameContextKey] == null) return false;
            var currentPermissionTypes =(Dictionary<PermissionType,string>) context.Session[Global.GlobalConsts.PermissionTypeToNameContextKey];

            if (currentPermissionTypes.All(c => c.Key != PermissionType.FullAccess) )
            {
                if (permissions.Length == 0) return false;
                foreach (var type in permissions)
                {
                    if (!canSee)
                    {
                        canSee = currentPermissionTypes.Any(c => c.Key == type);
                    }

                }
            }
            else
            {
                return true;
            }
            return canSee;
        }
    }
}