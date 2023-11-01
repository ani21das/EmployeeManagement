using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Leave
    {
        [Key]
        public int LeaveID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string LeaveType { get; set; }

        public string Status { get; set; }
    }
}