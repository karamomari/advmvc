namespace AdvProject.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ManegerName { get; set; }
        public List<Employee>? employees{ get; set; }
        public List<Course>? courses { get; set; }

        public List<Trainee> trainees { set; get; }

        public List<Instructore> instructores { set; get; }



    }
}
