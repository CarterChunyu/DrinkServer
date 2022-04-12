using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkServer.ViewModels
{
    public class UserVM
    {
        public UserVM()
        {
            TeamCheckVMs = new List<TeamCheckVM>();
        }
        [Required(ErrorMessage = "Please enter a DisplayName .")]
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter a Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password fields do not match. Please try again.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public bool Status { get; set; }
        public int? TeamId { get; set; }

        public List<TeamCheckVM> TeamCheckVMs { get; set; }
    }
    public class UserCreateVM : UserVM
    {
        [Remote(action: "IsNameExisted", controller: "User")]
        [Required(ErrorMessage = "Please enter a LoginName .")]
        public string LoginName { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class UserEditVM : UserVM
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a LoginName .")]
        public string LoginName { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class TeamCheckVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Flag { get; set; }
    }
    public class ProfileUserVM
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter a DisplayName .")]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }
    }
    public class ProfilePasswordVM
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter CurrentPasswrod")]
        [Remote(action: "IsPsCorrect", controller:"Login")]
        public string CurrentPasswrod { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter NewPasswrod")]
        public string NewPasswrod { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Confirm Password")]
        [Compare("NewPasswrod", ErrorMessage = "The Password and Confirm Password fields do not match. Please try again.")]
        public string ComparePasswrod { get; set; }
    }

    public class AdminChangePasswordVM
    {
        public int UserId { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter NewPasswrod")]
        public string NewPasswrod { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Confirm Password")]
        [Compare("NewPasswrod", ErrorMessage = "The Password and Confirm Password fields do not match. Please try again.")]
        public string ComparePasswrod { get; set; }
    }
}
