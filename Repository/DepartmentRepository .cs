using AdvProject.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.ComponentModel.DataAnnotations;

namespace AdvProject.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIContext context;
        public DepartmentRepository(ITIContext context)
        {
            //وهون خلص هو محقون رح يدورلي عليه مباشره رح يجيبه لانه رح يلاقيه انه عامله
            this.context = context;
        }


        public void Add(Department obj)
        {
            context.Add(obj);
        }

        public void Update(Department obj)
        {
            context.Update(obj);
        }

        public void Delete(Department obj)
        {
            context.Remove(obj);
        }


        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
