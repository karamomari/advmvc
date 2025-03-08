using AdvProject.Models;
using AdvProject.ViewModel;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvProject.Controllers
{
    public class DepartmentController : Controller
    {




        /*
         * الـ Dependency Injection 
         * بيشتغل إنه عند كل Request،
         * الفريمورك بيشوف الكنترولر شو محتاج،
         * وإذا لقى إنه بده ITIContext، 
         * بيخلقه تلقائيًا باستخدام AddDbContext،
         * وبعد انتهاء الطلب بيحذفه وبيجهز واحد جديد للطلب اللي بعده. 🔄
         * وممكن يلاقيله بلحاويه تبعته بممرله اياه بدون ما يولد واحد
   */

        private readonly ITIContext context;
        public DepartmentController(ITIContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Department> departmentList =context.Departments.Include(d=>d.employees).ToList();
            return View("Index",departmentList);
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SaveDep(Department newDepartment)
        {
            //return Content(Request.GetDisplayUrl());
            if (newDepartment.Name != null)
            {
                context.Departments.Add(newDepartment);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", newDepartment);

        }

    }
}
