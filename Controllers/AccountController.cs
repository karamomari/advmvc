using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdvProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> sign;
        private readonly ITIContext context;
        private readonly RoleManager<IdentityRole> role;


        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> sign,ITIContext context, RoleManager<IdentityRole> role)
        {
            this.userManager = userManager;
            this.sign = sign;
            this.context = context;
            this.role = role;

        }



        [Authorize(Roles ="Admin")]

        public IActionResult idex()
        {
           
            if(User.Identity.IsAuthenticated == true)
            {
            Claim claim=User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                Claim claim1 = User.Claims.FirstOrDefault(c => c.Type == "Id");
                string userRole = claim1 != null ? claim1.Value : "Not Assigned";

                return Content($"wellcone {User.Identity.Name} \n ID = {claim.Value} \n Role = {userRole}");
            }

            return Content("wellcome Guset");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.PasswordHash = registerUser.Password;
                applicationUser.UserName = registerUser.UserName;
                applicationUser.Address = registerUser.Address;
                 IdentityResult result=  await userManager.CreateAsync(applicationUser,registerUser.Password);
                if (result.Succeeded==true)
                {
                    await sign.SignInAsync(applicationUser,  false);
                    return RedirectToAction("index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register",registerUser);
        }


        public async Task<IActionResult> signout()
        {
            await sign.SignOutAsync();
            return RedirectToAction("index", "Department");

        }
        public IActionResult Login() 
        {
            return View();
        }


        public async Task<IActionResult> SaveLogin(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser user=await userManager.FindByNameAsync(loginViewModel.UserName);

                if (user != null)
                {
                  bool pass=  await  userManager.CheckPasswordAsync(user, loginViewModel.password);

                    if (pass==true)
                    {
                     //  await sign.SignInAsync(user, loginViewModel.Remberme);
                     List <Claim> claims=new List<Claim>();
                        claims.Add(new Claim("Id",user.Id));


                       await sign.SignInWithClaimsAsync(user, loginViewModel.Remberme,claims);



                        return RedirectToAction("index", "Department");
                    }
                }
                ModelState.AddModelError("", "This Iser Name not Exits");
            }
            return View("Login", loginViewModel);
        }





        [HttpGet]
        public IActionResult RegisterWithRole()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegisterwithRole(RegisterUserViewModelWithRole registerUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.PasswordHash = registerUser.Password;
                applicationUser.UserName = registerUser.UserName;
                applicationUser.Address = registerUser.Address;
                IdentityResult result = await userManager.CreateAsync(applicationUser, registerUser.Password);
                if (result.Succeeded == true)
                {

                    if (registerUser.Roles != null && registerUser.Roles.Count > 0)
                    {
                        foreach (var roleName in registerUser.Roles)
                        {
                            // التأكد من أن الدور موجود في قاعدة البيانات
                            var roleExists = await role.RoleExistsAsync(roleName);
                            if (!roleExists)
                            {
                                await role.CreateAsync(new IdentityRole(roleName));
                            }

                            // إضافة المستخدم إلى الدور
                            await userManager.AddToRoleAsync(applicationUser, roleName);
                        }
                    }
                    await sign.SignInAsync(applicationUser, false);
                    return RedirectToAction("index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("RegisterWithRole", registerUser);
        }

    }
}
