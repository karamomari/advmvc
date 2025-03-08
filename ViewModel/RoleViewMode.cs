using System.ComponentModel.DataAnnotations;

namespace AdvProject.ViewModel
{
    public class RoleViewMode
    {
        [Display(Name = "Role Name")]
        [Required]
        public string RoleName { get; set; }
    }

}
