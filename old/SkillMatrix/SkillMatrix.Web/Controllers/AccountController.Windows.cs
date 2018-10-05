﻿// <copyright file="AccountController.Windows.cs" auther="Mohammad Younes">
// Copyright 2013 Mohammad Younes.
// 
// Released under the MIT license
// http://opensource.org/licenses/MIT
//
// </copyright>

using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SkillMatrix.DomainModel.Identity;
using SkillMatrix.Web.Core.Windows;
using SkillMatrix.Web.Models;

namespace SkillMatrix.Web.Controllers
{
  [Authorize]
  public partial class AccountController
  {
    //
    // POST: /Account/WindowsLogin
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<ActionResult> WindowsLogin(string userName, string returnUrl)
    {
      if (!Request.LogonUserIdentity.IsAuthenticated)
      {
        return RedirectToAction("Login");
      }

      var loginInfo = GetWindowsLoginInfo();

      // Sign in the user with this external login provider if the user already has a login
      var user = await UserManager.FindAsync(loginInfo);
      if (user != null)
      {
        await SignInManager.SignInAsync(user, false, true);
        return RedirectToLocal(returnUrl);
      }
      else
      {
        // If the user does not have an account, then prompt the user to create an account
        var name = userName;
        if (string.IsNullOrEmpty(name))
          name = Request.LogonUserIdentity.Name.Split('\\')[1];
        var appUser = new Account() {  UserName = name};
        var result = await UserManager.CreateAsync(appUser);
        if (result.Succeeded)
        {
          result = await UserManager.AddLoginAsync(appUser.Id, loginInfo);
          if (result.Succeeded)
          {
              await SignInManager.SignInAsync(user, false, true);
                        return RedirectToLocal(returnUrl);
          }
        }
        AddErrors(result);
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.LoginProvider = "Windows";
        return View("WindowsLoginConfirmation", new WindowsLoginConfirmationViewModel { UserName = name });
      }
    }

    //
    // POST: /Account/WindowsLogOff
    [HttpPost]
    [ValidateAntiForgeryToken]
    public void WindowsLogOff()
    {
      AuthenticationManager.SignOut();
    }

    //
    // POST: /Account/LinkWindowsLogin
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> LinkWindowsLogin()
    {
      string userId = HttpContext.ReadUserId();

      //didn't get here through handler
      if (string.IsNullOrEmpty(userId))
        return RedirectToAction("Login");

      HttpContext.Items.Remove("windows.userId");

      //not authenticated.
      var loginInfo = GetWindowsLoginInfo();
      if (loginInfo == null)
        return RedirectToAction("Manage");

      //add linked login
      var result = await UserManager.AddLoginAsync(userId, loginInfo);

      //sign the user back in.
      var user = await UserManager.FindByIdAsync(userId);
      if (user != null)
          await SignInManager.SignInAsync(user, false, true);

            if (result.Succeeded)
        return RedirectToAction("Manage");

      return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
    }

    #region helpers
    private UserLoginInfo GetWindowsLoginInfo()
    {
      if (!Request.LogonUserIdentity.IsAuthenticated)
        return null;

      return new UserLoginInfo("Windows", Request.LogonUserIdentity.User.ToString());
    }
    #endregion
  }
}