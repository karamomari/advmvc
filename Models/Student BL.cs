namespace AdvProject.Models
{
    public class Student_BL
    {
        public List<Student> students;
        public Student_BL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "karam", Image = "1.jpg" });
            students.Add(new Student() { Id = 1, Name = "mohammad", Image = "2.webp" });
            students.Add(new Student() { Id = 1, Name = "ahmed", Image = "1.jpg" });
            students.Add(new Student() { Id = 1, Name = "alomari", Image = "2.webp" });

        }

        public List<Student> GetAll()
        {
            return students;
        }


        public Student GetID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }


    }
}
