using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SkillMatrix.Common.Enums;
using SkillMatrix.Data.Contexts;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.Data.Configurations.Identity
{
	public class AccountRoleStore : RoleStore<AccountRole, string, AccountUserRole>
	{
		public AccountRoleStore(SKMContext context)
			: base(context)
		{
		}

		public int MyProperty { get; set; }
	}


	public class AccountRoleManager : RoleManager<AccountRole, string>
	{
		private IRoleStore<AccountRole, string> _store;

		public AccountRoleManager(IRoleStore<AccountRole, string> store)
			: base(store)
		{
			_store = store;
		}

		//public static AccountRoleManager RoleManager { get; set; }
		public static AccountRoleManager Create(IdentityFactoryOptions<AccountRoleManager> options,
			IOwinContext context)
		{
			//var roleStore = new RoleStore<AccountRole,string>(context.Get<AppIdentityDbContext>());
			//return new AccountRoleManager(roleStore);
			var roleManager =
				new AccountRoleManager(new RoleStore<AccountRole, string, AccountUserRole>(context.Get<SKMContext>()));
			//RoleManager = roleManager;
			return roleManager;
		}

		public bool CreateRole(AccountRole role)
		{
			var _retVal = false;
			try
			{
				var roleManager =
					new RoleManager<AccountRole, string>(new RoleStore<AccountRole, string, AccountUserRole>(new SKMContext()));
				if (!roleManager.RoleExists(role.Name)) roleManager.Create(role);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return _retVal;
		}

		public bool AddPermission(AccountPemission newPermission)
		{
			var retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					db.AccountPemissions.Add(newPermission);
					db.Entry(newPermission).State = EntityState.Added;
					db.SaveChanges();
					retVal = true;
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}

		public bool AddUpdatePermission(AccountPemission newPermission)
		{
			var retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					var permission = db.AccountPemissions.FirstOrDefault(c => c.Name == newPermission.Name);
					if (permission == null)
					{
						db.AccountPemissions.Add(newPermission);
						db.Entry(newPermission).State = EntityState.Added;
						db.SaveChanges();
						retVal = true;
					}
					else
					{
						retVal = true;
					}
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}


		#region Worker functions for AccountPemissions

		public List<AccountPemission> GetAccountPemissions()
		{
			List<AccountPemission> retVal = null;
			try
			{
				using (var db = new SKMContext())
				{
					retVal = db.AccountPemissions.OrderBy(p => p.Name).Include(c => c.Roles).ToList();
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}

		public AccountPemission GetAccountPemissionById(string permissionId)
		{
			AccountPemission retVal = null;
			try
			{
				using (var db = new SKMContext())
				{
					retVal = db.AccountPemissions.Where(p => p.PermissionId == permissionId).Include(c => c.Roles).FirstOrDefault();
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}

		public AccountPemission GetAccountPemission(string permissionName)
		{
			AccountPemission retVal = null;
			try
			{
				using (var db = new SKMContext())
				{
					retVal = db.AccountPemissions.Where(p => p.Name == permissionName).Include(c => c.Roles).FirstOrDefault();
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}

		public bool AddPermissionToRole(string roleId, string permissionId)
		{
			var retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					var role = db.Roles.Where(p => p.Id == roleId).Include(c => c.Permissions).FirstOrDefault();
					if (role != null)
					{
						var permission = db.AccountPemissions.Where(p => p.PermissionId == permissionId).Include(c => c.Roles)
							.FirstOrDefault();
						if (!role.Permissions.Contains(permission))
						{
							role.Permissions.Add(permission);
							//role.LastModified = DateTime.Now;
							db.Entry(role).State = EntityState.Modified;
							db.SaveChanges();
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return retVal;
		}

		public bool AddPermissionToRole(string roleId, PermissionType permissionType)
		{
			var retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					var role = db.Roles.Where(p => p.Id == roleId).Include(c => c.Permissions).FirstOrDefault();
					if (role != null)
					{
						var permission = db.AccountPemissions.Where(p => p.Type == permissionType).Include(c => c.Roles).FirstOrDefault();
						if (!role.Permissions.Contains(permission))
						{
							role.Permissions.Add(permission);
							//role.LastModified = DateTime.Now;
							db.Entry(role).State = EntityState.Modified;
							db.SaveChanges();
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return retVal;
		}

		public bool AddPermissionsToRole(Enum[] permissionTypes, AccountRole projectAdmin)
		{
			var retVal = false;

			foreach (var permissionType in permissionTypes)
			{
				var permissionEnumType = (PermissionType) permissionType;
				var result = AddPermissionToRole(projectAdmin.Id, permissionEnumType);
				if (retVal && !result)
					retVal = false;
				else
					retVal = true;
			}

			return retVal;
		}

		public bool AddAllPermissions2Role(string roleId)
		{
			var _retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					var role = db.Roles.Where(p => p.Id == roleId).Include(c => c.Permissions).FirstOrDefault();
					if (role != null)
					{
						var permissions = db.AccountPemissions.Include(c => c.Roles).ToList();
						foreach (var permission in permissions)
							if (!role.Permissions.Contains(permission))
								role.Permissions.Add(permission);
						//role.LastModified = DateTime.Now;
						db.Entry(role).State = EntityState.Modified;
						db.SaveChanges();
						_retVal = true;
					}
				}
			}
			catch
			{
			}

			return _retVal;
		}


		public bool RemovePermission4Role(string roleId, string permissionId)
		{
			var _retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					var role = db.Roles.Where(p => p.Id == roleId).Include(c => c.Permissions).FirstOrDefault();
					var permission = db.AccountPemissions.Where(p => p.PermissionId == permissionId).Include(c => c.Roles)
						.FirstOrDefault();

					if (role != null && role.Permissions.Contains(permission))
					{
						role.Permissions.Remove(permission);
						//_role2Modify.LastModified = DateTime.Now;
						db.Entry(role).State = EntityState.Modified;
						db.SaveChanges();

						_retVal = true;
					}
				}
			}
			catch (Exception)
			{
			}

			return _retVal;
		}


		public bool AddAccountPemission(AccountPemission permission)
		{
			var retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					db.AccountPemissions.Add(permission);
					db.Entry(permission).State = EntityState.Added;
					db.SaveChanges();
					retVal = true;
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}

		public bool UpdateAccountPemission(AccountPemission permission)
		{
			var retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					db.Entry(permission).State = EntityState.Modified;
					db.SaveChanges();
					retVal = true;
				}
			}
			catch (Exception)
			{
			}

			return retVal;
		}

		public bool DeleteAccountPemission(string permissionId)
		{
			var _retVal = false;
			try
			{
				using (var db = new SKMContext())
				{
					var AccountPemission = db.AccountPemissions.Where(p => p.PermissionId == permissionId).Include(c => c.Roles)
						.FirstOrDefault();

					if (AccountPemission != null)
					{
						AccountPemission.Roles.Clear();
						db.Entry(AccountPemission).State = EntityState.Deleted;
					}

					db.SaveChanges();
					_retVal = true;
				}
			}
			catch (Exception)
			{
			}

			return _retVal;
		}

		#endregion
	}
}