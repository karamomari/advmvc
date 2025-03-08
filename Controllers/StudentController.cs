using AdvProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult GetAll()
        {
            Student_BL studentBL = new Student_BL();
            List<Student> students = studentBL.GetAll();
            return View("index",students);
        }

        public IActionResult getId(int id)
        {
            Student_BL studentBL = new Student_BL();
            Student students = studentBL.GetID(id);
            return View("onestudent",students);
        }
    }
}
