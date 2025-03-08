using AdvProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdvProject.Controllers
{
    public class testController : Controller
    {
        private readonly ITIContext context;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public testController(ITIContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // المشكله هاض فيش غيره خلص بزبطش تبع الديفيلت
        [Route("m1/{Age:int:range(10,20)}/{color}",Name ="R1")]
        public IActionResult methodone(int age,string color)
        {
            return Content($"the age {age} \n the color {color}");
        }
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel registerUserView)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = registerUserView.UserName;
                applicationUser.Address = registerUserView.Address;

                IdentityResult identityResult = await userManager.CreateAsync(applicationUser, registerUserView.Password);

                if (identityResult.Succeeded)
                {
                    IdentityResult identityResultRole=  await userManager.AddToRoleAsync(applicationUser, "Admin");
                    if (identityResultRole.Succeeded)
                    {

                        List<Claim> claim = new List<Claim>
                        {
                           new Claim("Address", applicationUser.Address),
                           new Claim("Id", applicationUser.Id)
                        };

                        await signInManager.SignInWithClaimsAsync(applicationUser, false, claim);
                        ModelState.Clear();
                        return RedirectToAction("index", "Department");
                    }
                    else
                    {
                        foreach (var item in identityResultRole.Errors)
                        {
                            ModelState.AddModelError("", item.Description);

                        }
                        return View("Register", registerUserView);

                    }
                }
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", registerUserView);
        }



        public IActionResult login()
        {
            return View("login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Savelogin(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
              ApplicationUser applicationUser=await  userManager.FindByNameAsync(loginViewModel.UserName);
                if (applicationUser!=null)
                {
                  bool su=  await userManager.CheckPasswordAsync(applicationUser, loginViewModel.password);
                    if (su == true)
                    {


                        List<Claim> claims = new List<Claim>
                        {
                            new Claim("Id",applicationUser.Id),
                            new Claim("Id",applicationUser.Address),

                        };
                      await signInManager.SignInWithClaimsAsync(applicationUser, loginViewModel.Remberme, claims);
                        return RedirectToAction("index", "Department");


                    }
                    ModelState.AddModelError("password", "Password incoorect");
                }
                ModelState.AddModelError("UserName", "This user not exists");
            }
            return View("login", loginViewModel);
        }
    }
}
