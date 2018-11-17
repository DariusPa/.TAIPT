using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginViewModel
    {
        // Login logic
    }

    public class ConnectToDashboardViewModel
    {
        // Login logic
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "The surname is required")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}