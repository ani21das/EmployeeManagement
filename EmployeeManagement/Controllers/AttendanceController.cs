using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendance(Attendance attendance)
        {
            try
            {
                // Check if the employee exists
                if (!_context.Employees.Any(e => e.EmployeeID == attendance.EmployeeID))
                {
                    return BadRequest("Employee not found.");
                }

                // Implement logic to check and handle attendance status

                _context.Attendance.Add(attendance);
                await _context.SaveChangesAsync();
                return Ok("Attendance marked successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("status/{employeeId}")]
        public async Task<IActionResult> GetAttendanceStatus(int employeeId)
        {
            try
            {
                // Retrieve the attendance status for the specified employee
                var attendance = await _context.Attendance
                    .Where(a => a.EmployeeID == employeeId)
                    .ToListAsync();

                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
