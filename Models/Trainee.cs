using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace AdvProject.Models
{
    public class Trainee
    {
        public int ID { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public string address { get; set; }
        public string image { get; set; }

        public string grade { get; set; }

        [ForeignKey("Department")]
        public int dept_id { set;get;}

        public Department department;

    }
}
