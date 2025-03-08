using System.ComponentModel.DataAnnotations;

namespace AdvProject.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        public string Password { get; set;}
        
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Password Confirmed")]
        public string PasswordConfirmed { get; set;}
        public string Address { get; set;}

        //public string Email { get; set;}
        //public string EmailConfirmed { get; set;}
    }
}
