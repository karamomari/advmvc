using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvProject.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser> //DbContext
    {

        public DbSet<Employee> Employees { set; get;}
        public DbSet<Department> Departments { set; get; }

        public DbSet<Trainee> Trainees { set; get; }
        public DbSet<Instructore> Instructores { set; get; }
        public DbSet<Course> Courses { set; get; }

        public DbSet<crsREsult> crsREsults { set; get; }


        public ITIContext():base()
        {
            // هيك مش حاقن فيه اشي ف ما رح يدورلي عليه بالكونتينر 
        }
        //اي اشي معموله حقن بدور عليه بالكونتينر هو لحاله
        public ITIContext(DbContextOptions<ITIContext> options):base(options)
        {
            //  يعني بس حدا يطلبه ييجي ينشئ هاض الكونستركتر بلاقيه بوخذ كونكشن ف بروح على الكونتينر وبنشء واحد معه الكوكشن جاهز
        }

    }
}
