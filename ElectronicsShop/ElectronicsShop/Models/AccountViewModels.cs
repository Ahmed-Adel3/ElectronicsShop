using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "NotValidMail")]
        [Display(Name = "EmailLbl")]
        public string Email { get; set; }

        [Required(ErrorMessage = "RequiredPassword")]
        [Display(Name = "PasswordLbl")]
        [DataType(DataType.Password, ErrorMessage = "WeakPasswordCombination")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="RequiredFullName")]
        [Display(Name = "FullNameLbl")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "RequiredPassword")]
        [Display(Name = "PasswordLbl")]
        [DataType(DataType.Password , ErrorMessage ="WeakPasswordCombination")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        [DataType(DataType.Password, ErrorMessage = "WeakPasswordCombination")]
        [Display(Name = "ConfirmPasswordLbl")]
        [Compare("Password", ErrorMessage = "PasswordsNotTheSame")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "NotValidMail")]
        [Display(Name = "EmailLbl")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneRequired")]
        [RegularExpression(@"^(01)[0-9]{9}$", ErrorMessage = "PhoneNotValid")]
        [Display(Name = "PhoneLbl")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "AddressRequired")]
        [Display(Name = "AddressLbl")]
        public string Address { get; set; }

        [Required(ErrorMessage = "DateOfBirthRequired")]
        [Display(Name = "DateOfBirthLbl")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
