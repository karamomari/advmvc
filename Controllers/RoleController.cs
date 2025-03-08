using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> role;
        public RoleController(RoleManager<IdentityRole> role)
        {
            this.role = role;
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewMode roleView)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole=new IdentityRole();
                identityRole.Name = roleView.RoleName;
              IdentityResult result=  await role.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("index", "Department");

                }

                foreach (var item in result.Errors)
                {
                ModelState.AddModelError("",item.Description);

                }
            }
            return View("AddRole",roleView);

        }
    }
}
