using AdvProject.Models;
using AdvProject.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews(op =>
            {
                op.Filters.Add(new HandelErroreAttribute());
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op =>
            {

                op.Password.RequiredLength = 4;
                op.Password.RequireDigit = false;
                op.Password.RequireNonAlphanumeric = false;
            })
            //عشان الانجكت شو توخذ 
                .AddEntityFrameworkStores<ITIContext>(); // اشتغلي على الكونتمست تبعي مش الي بالبكج الي هو ادينتيتي


            builder.Services.AddDbContext<ITIContext>(op =>
            //اول اشي بضيفه بالكونتينر هون 
            //طبعا عندي اكثر من الطريقه الثانيه سهله الثانيه نفسها بس الفرق 
            //اني بقرا من الاب سستنج عن طريق الكونفق الموجوده
            op.UseSqlServer(builder.Configuration.GetConnectionString("DB"))
            //
            //op.UseSqlServer("Data Source=DESKTOP-52LGDNN\\DB_20199980187;Initial Catalog=AdvMvc;Integrated Security=True;TrustServerCertificate=true;")
            );

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //addsingelton
            //   builder.Services.AddScoped<IEmployeeRepository, MongoEmployeeRepository>();
            //   builder.Services.AddScoped<IDepartmentRepository, MogoDepartmentRepository>();

            builder.Services.AddDistributedMemoryCache(); // مهم للجلسات
            builder.Services.AddSession(op =>
            {
                op.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            var app = builder.Build();

            //builder.Services.AddDbContext<ITIContext>(options =>
            //   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            //);



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseExceptionHandler("//learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio");

                //
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // to convert req htttp to https
            app.UseStaticFiles(); //to direcft to wwwroot


            app.UseRouting(); //to direct to controller and action
            app.UseAuthentication();
            app.UseAuthorization(); //Authorization but قبله لاوم authintion

            //app.UseMvc();
            app.UseSession();

            //app.MapControllerRoute("totest", "rr/{age:int:range(20,50)}/{color?}",

            //     new { controller = "test", action = "methodone" }
            //    ) ;


            //app.MapControllerRoute(
            //       name: "Route1",
            //         pattern: "R/{action}",
            //      defaults: new { controller = "Test", action = "Index" }
            //     );


            app.MapControllerRoute("s", "RR/{action=methodone}",
                new { controller = "Test" }
                );


            app.MapControllerRoute( //to direct to controller and action
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
