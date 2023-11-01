using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/hr")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HRController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("approve/{leaveId}")]
        public async Task<IActionResult> ApproveLeave(int leaveId)
        {
            try
            {
                var leave = await _context.Leaves.FindAsync(leaveId);

                if (leave == null)
                {
                    return NotFound("Leave request not found.");
                }

                // Implement leave request approval logic
                leave.Status = "Approved";

                _context.Entry(leave).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok("Leave request approved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("reject/{leaveId}")]
        public async Task<IActionResult> RejectLeave(int leaveId)
        {
            try
            {
                var leave = await _context.Leaves.FindAsync(leaveId);

                if (leave == null)
                {
                    return NotFound("Leave request not found.");
                }

                // Implement leave request rejection logic
                leave.Status = "Rejected";

                _context.Entry(leave).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok("Leave request rejected successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("all-leaves")]
        public async Task<IActionResult> GetAllLeaveRequests()
        {
            try
            {
                var leaves = await _context.Leaves.ToListAsync();
                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
