

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AdvProject.Controllers
{
    //[HandelErrore]
    public class EmployeeController : Controller
    {
        private readonly ITIContext context;

        IEmployeeRepository employeeRepository;
        IDepartmentRepository departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,IDepartmentRepository departmentRepository)
        {


            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;

            ////  رح ىييجي الكونترولر فاكتور  يحاول ينشئ اوبجكت من هاض الكلاس 
            ///رح يكتشف انه بوخذ مش ديفيلف كونستركتر بوخذ هاي الاشياء بروح بسال اشي 
            ///  اسمه سيرفيس بروفايدر عندك اشي لهضول بقله اه لاني كنت ض ايق هاي الجزئيات 
            ///  builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            ///builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            ///يعني لما ينطلب انترفيس الموظفين اعطيه EmployeeRepository
            ///ولما ينطلب انترفيس الاقسام اعطيه DepartmentRepository

        }

        [Authorize]
        public IActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Employee> employee = employeeRepository.GetAll();

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            
            ViewBag.QueryTime = elapsedTime.TotalMilliseconds;


            HttpContext.Response.Cookies.Append("test", "testt");

            return View("Index", employee);
        }

        
        public IActionResult partialdet(int id)
        {
            return PartialView("cardEmp", employeeRepository.GetById(id));
        }


        public IActionResult DepEmp()
        {
            return View("EmpDep",departmentRepository.GetAll());
        }

        public IActionResult GetEmpByIDDep(int Depid)
        {
            List<Employee> employees = employeeRepository.GetByDepId(Depid);
            return Json(employees);
        }

        public IActionResult CheakName(string Name,string Adrress)
        {
            if (Name.Contains("EMP")) { 
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult Add()
        {
            ViewBag.Dep = departmentRepository.GetAll();
            ViewBag.co= HttpContext.Request.Cookies["test"];
            return View();
        }

        [HttpPost]
        public IActionResult SaveEmp(Employee employee)
        {
            if (ModelState.IsValid == false)
            {

                ViewBag.Dep = departmentRepository.GetAll(); //context.Departments.ToList();
                return View("Add", employee);
            }
            if (employee.DepartmentID == -1)
            {
                ModelState.AddModelError("DepartmentID", "Please chose Dempartment  😊");
                ViewBag.Dep = departmentRepository.GetAll();//context.Departments.ToList();
                return View("Add", employee);
            }
            //context.Employees.Add(employee);
            //context.SaveChanges();

            employeeRepository.Add(employee);
            employeeRepository.Save();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Employee employee = employeeRepository.GetById(id); //context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> department = departmentRepository.GetAll(); // context.Departments.ToList();
            ViewBag.departments = department;

            HttpContext.Response.Cookies.Append("test", "testt");

            ViewBag.co = HttpContext.Request.Cookies["test"];
            

            return View("Edit", employee);
        }











        public IActionResult SaveEditt(Employee EmpFromRequest, int id)
        {

            if (ModelState.IsValid)
            {
                // البحث عن الموظف في قاعدة البيانات باستخدام الـ ID
                var EmpFromDB = employeeRepository.GetById(id);
                    //context.Employees.FirstOrDefault(e => e.Id == id);

                if (EmpFromDB != null)
                {
                    EmpFromDB.Adrress = EmpFromRequest.Adrress;
                    EmpFromDB.Name = EmpFromRequest.Name;
                    EmpFromDB.Salary = EmpFromRequest.Salary;
                    EmpFromDB.JobTitle = EmpFromRequest.JobTitle;
                    EmpFromDB.ImageURL = EmpFromRequest.ImageURL;
                    EmpFromDB.DepartmentID = EmpFromRequest.DepartmentID;

                    employeeRepository.Update(EmpFromDB);
                    employeeRepository.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

            return View("Edit", EmpFromRequest);
        }

    }
}
