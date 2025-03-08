using System.ComponentModel.DataAnnotations;

namespace AdvProject.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="User Name")]
        [Required]
        public string UserName { set; get; }
        
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Rember me !")]
        public bool Remberme { get; set; }
    }
}
