using AdvProject.Models;

namespace AdvProject.Repository
{
    public interface IDepartmentRepository
    {



        public void Add(Department obj);



        public void Update(Department obj);


        public void Delete(Department obj);



        public Department GetById(int id);



        public List<Department> GetAll();

        public void Save();
     
    }
}
