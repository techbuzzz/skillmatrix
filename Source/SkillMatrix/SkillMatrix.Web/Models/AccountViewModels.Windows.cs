// <copyright file="AccountViewModels.Windows.cs" auther="Mohammad Younes">
// Copyright 2013 Mohammad Younes.
// 
// Released under the MIT license
// http://opensource.org/licenses/MIT
//
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Web.Models
{
  public class WindowsLoginConfirmationViewModel
  {
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; }
  }

}