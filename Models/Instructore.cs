using System.ComponentModel.DataAnnotations.Schema;

namespace AdvProject.Models
{
    public class Instructore
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string salary { get; set; }

        public string? image { get; set; }
        public string? address { get; set; }

        public string? grade { set; get; }

        [ForeignKey("Department")]
        public int dept_id { set; get; }


        [ForeignKey("Course")]
        public int crs_id { set; get; }

        [ForeignKey("dept_id")]
        public Department department { set; get; }

        [ForeignKey("crs_id")]
        public Course? course { set; get; }




    }
}
