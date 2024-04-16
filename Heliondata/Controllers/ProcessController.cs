using Heliondata.Data;
using Heliondata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {

        private readonly HelionDBContext _context;

        public ProcessController(HelionDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Process>> SaveProcess(Process process)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                _context.Processes.Add(process);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProcessById), new { id = process.ID }, process);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Failed to save process.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Process>> GetProcessById(int id)
        {
            var process = await _context.Processes.FindAsync(id);

            if (process == null)
            {
                return NotFound();
            }

            return Ok(process);
        }
    }
}