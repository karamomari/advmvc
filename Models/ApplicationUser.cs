using Microsoft.AspNetCore.Identity;

namespace AdvProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
