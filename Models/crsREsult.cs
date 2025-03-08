using System.ComponentModel.DataAnnotations.Schema;

namespace AdvProject.Models
{
    public class crsREsult
    {

        public int ID { get; set; }

        public int degree { get; set; }

        [ForeignKey("Course")]
        public int crs_id { get; set; }
        
        [ForeignKey("Trainee")]
        public int traninee_id { get; set; }

        public Course Course { get; set; }

        public Trainee Trainee { get; set; }




    }
}
