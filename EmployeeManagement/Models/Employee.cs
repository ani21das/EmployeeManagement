using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [ForeignKey("Department")] // Declare DepartmentID as a foreign key
        public int? DepartmentID { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }
    }

}
