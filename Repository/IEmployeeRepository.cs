using AdvProject.Models;

namespace AdvProject.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee obj);

        public void Update(Employee obj);

        public void Delete(Employee obj);


        public Employee GetById(int id);

        public List<Employee> GetByDepId(int id);

        public List<Employee> GetAll();
        public void Save();


    }
}
