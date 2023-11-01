using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Route("api/leaves")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForLeave(Leave leave)
        {
            try
            {
                if (!_context.Employees.Any(e => e.EmployeeID == leave.EmployeeID))
                {
                    return BadRequest("Employee not found.");
                }
                leave.Status = "Pending";

                _context.Leaves.Add(leave);
                await _context.SaveChangesAsync();
                return Ok("Leave request created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpGet("status/{employeeId}")]
        public async Task<IActionResult> CheckLeaveStatus(int employeeId)
        {
            try
            {
                var leaves = await _context.Leaves.Where(l => l.EmployeeID == employeeId).ToListAsync();
                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeave(int id, Leave updatedLeave)
        {
            if (id != updatedLeave.LeaveID)
            {
                return BadRequest("Invalid request");
            }

            try
            {
                if (!LeaveExists(id))
                {
                    return NotFound("Leave request not found.");
                }
                _context.Entry(updatedLeave).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Leave request updated successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Concurrency error: Leave request was updated by another user.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        private bool LeaveExists(int id)
        {
            return _context.Leaves.Any(l => l.LeaveID == id);
        }
    }
}