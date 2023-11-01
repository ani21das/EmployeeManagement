using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

}
