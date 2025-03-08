using Microsoft.AspNetCore.Mvc;

namespace AdvProject.Controllers
{
    public class SessionController : Controller
    {
      public IActionResult Setsission(string name)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 22);
            return Content("session sucess saved");
        }


        public IActionResult GEtsission(string name)
        {

            HttpContext.Session.SetString("Name", name);

            string n = HttpContext.Session.GetString("Name");



           int? a= HttpContext.Session.GetInt32("Age");
            return Content($"session Name :  {n} and Age : {a}");
        }


        //public IActionResult cookes()
        //{
        //    HttpContext.Response.Cookies["test"];

        //}
    }
}
