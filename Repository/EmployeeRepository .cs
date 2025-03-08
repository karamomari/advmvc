
namespace AdvProject.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {

        ITIContext context;
        public EmployeeRepository(ITIContext context)
        {
            this.context = context;
        }


        public void Add(Employee obj)
        {
            context.Add(obj);
        }

        public void Update(Employee obj)
        {
            context.Update(obj);
        }

        public void Delete(Employee obj)
        {
            context.Remove(obj);
        }


        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(d => d.Id == id);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Employee> GetByDepId(int id)
        {
            return context.Employees.Where(e => e.DepartmentID == id).ToList();
        }
    }
}
