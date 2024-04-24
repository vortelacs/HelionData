using Heliondata.Models;
using Heliondata.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessServ = Heliondata.Services.ProcessService;

namespace Heliondata.Controllers
{
    [ApiController]
    public class ProcessController : ControllerBase
    {

        private ProcessServ _processService;

        public ProcessController(ProcessServ processService)
        {
            _processService = processService;
        }


        [HttpPost("process")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> SaveProcess(ProcessCreateRequestDTO processDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                int savedId = await _processService.SaveProcess(processDTO);
                return CreatedAtAction(nameof(GetProcessById), new { id = savedId }, savedId);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Failed to save process.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpGet("process/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Process>> GetProcessById(int id)
        {
            var process = _processService.GetProcess(id);

            if (process == null)
            {
                return NotFound();
            }

            return Ok(process);
        }


        [HttpGet("processes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProcessInfoDTO>>> GetAllProcesses()
        {
            List<ProcessInfoDTO> process = _processService.GetAllProcess();

            if (process == null)
            {
                return NotFound();
            }

            return Ok(process);
        }


        [HttpDelete("process/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _processService.DeleteProcess(id);

        }
    }
}