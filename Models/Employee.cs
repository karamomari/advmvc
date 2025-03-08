using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdvProject.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20,ErrorMessage="err")]
        [UniqueNameG<Employee>("Name", ErrorMessage = "⚠️ Name must be unique.")]


        [Remote(action: "CheakName", controller: "Employee", AdditionalFields = "Adrress", ErrorMessage = "Name lazem ekon feh stu")]
        public string Name { get; set; }
        
  

        [Required(ErrorMessage = "This field (JobTitle) is required.")]
        [RegularExpression("Manger|IT|HR")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "This field (Salary) is required.")]
        [Range(300,1000)]
        public int Salary { get; set; }

        [Required(ErrorMessage = "This field (Adrress) is required.  😊")]
        [RegularExpression("Irbid|Amman")]
        public string Adrress { get; set; }

        [Required(ErrorMessage = "⚠️ This field (ImageURL) is required. 😊")]
        [RegularExpression(@".*\.(jpg|webp)$", ErrorMessage = "Only .jpg or .webp files are allowed.")]
        public string ImageURL { set; get; }

        [ForeignKey("Department")] 
        public int DepartmentID { set; get; }

        public Department? Department { set; get; }

    }
}
