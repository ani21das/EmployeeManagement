using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; } // Foreign key to link attendance with an employee

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; } // Example: "Present," "Absent," etc.
    }
}
