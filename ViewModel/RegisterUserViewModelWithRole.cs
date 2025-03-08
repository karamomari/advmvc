using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdvProject.ViewModel
{
    public class RegisterUserViewModelWithRole
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Password Confirmed")]
        public string PasswordConfirmed { get; set; }
        public string Address { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
