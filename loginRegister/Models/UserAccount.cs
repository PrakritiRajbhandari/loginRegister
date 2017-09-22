using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace loginRegister.Models
{
    public class UserAccount
    {
        [Key]
      
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage="Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}