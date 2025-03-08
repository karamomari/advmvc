using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvProject.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(1)]
        
        //[RegularExpression("[a-z|A-Z]")]

        [RegularExpression("karam|mohammad")]

        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public int degree { get; set; }
        public int minDegree { get; set; }

        [ForeignKey("Department")]
        public int dept_id { set; get; }
        public Department department { get; set; }

        public List<Instructore>? Instructores { get; set; }
    }
}
