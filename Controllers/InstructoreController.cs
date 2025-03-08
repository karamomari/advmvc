using AdvProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvProject.Controllers
{
    public class InstructoreController : Controller
    {
        private readonly ITIContext context;
        public InstructoreController(ITIContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Instructore> instructores = context.Instructores.AsNoTracking().ToList();
            return View("Index", instructores);
        }


        public IActionResult GetDetails(int id)
        {
            Instructore instructores = context.Instructores.Include(e => e.department).Include(e => e.course).FirstOrDefault(e => e.Id == id);

            return View("GetDetails", instructores);

        }

        public IActionResult add()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            return View();

        }
        [HttpPost]
        public IActionResult saveIns(Instructore instructore)
        {
            if (instructore.Name != null)
            {
                context.Instructores.Add(instructore);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            return View("add", instructore);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            var instructore = context.Instructores
               .Include(i => i.department) // تضمين بيانات القسم
               .Include(i => i.course)       // تضمين بيانات الكورس
               .FirstOrDefault(i => i.Id == id);

            if (instructore == null)
            {
                return NotFound(); // إذا لم يتم العثور على الموظف
            }

            return View("Edit", instructore);
        }

    }

}
