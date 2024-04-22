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
        public async Task<ActionResult<ProcessInfoDTO>> SaveProcess(ProcessCreateRequestDTO processDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProcessInfoDTO process = _processService.SaveProcess(processDTO).Result;
                return CreatedAtAction(nameof(GetProcessById), new { id = process.ID }, process);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Failed to save process.");
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