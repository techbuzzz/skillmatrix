using System;
using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.ViewModel
{

    public class AccountBaseViewModel
    {
        public AccountBaseViewModel()
        {
            IsActive = true;
            Id = Guid.NewGuid().ToString();
        }

        //[Display(Name = "Тип профиля")]
        //public ProfileType ProfileType { get; set; }

        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "PrimaryPhone")]
        public string PrimaryPhone { get; set; }

        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Global Administrator")]
        public bool IsGlobalAdmin { get; set; }

        [Display(Name = "Full Name")]
        public string DisplayName =>  $"{FirstName} {LastName}";


        [Display(Name = "Email Confirmed")]
        public string EmailConfirmedDisplay => EmailConfirmed?"Да":"Нет";

        [Display(Name = "Active")]
        public string IsActiveDisplay => IsActive ? "Да" : "Нет";


        public string DisplayNameSmall =>  $"{FirstName.Substring(0, 1)}{LastName.Substring(0, 1)}";



        //public string DisplayName => IsEnglish ? ExistLatinNames ? $"{FirstNameLatin} {LastNameLatin}" : $"{FirstName} {LastName}" : $"{FirstName} {LastName}";
        //public string DisplayFullName => IsEnglish ? ExistLatinNames ? $"{FirstNameLatin} {LastNameLatin} {MiddleName}" : $"{FirstName} {LastName} {MiddleName}" : $"{FirstName} {LastName} {MiddleName}";
        //public string DisplayNameSmall => IsEnglish ? ExistLatinNames ? $"{FirstNameLatin.Substring(0, 1)}{LastNameLatin.Substring(0, 1)}" : $"{FirstName.Substring(0, 1)}{LastName.Substring(0, 1)}" : $"{FirstName.Substring(0, 1)}{LastName.Substring(0, 1)}";

    }
}
