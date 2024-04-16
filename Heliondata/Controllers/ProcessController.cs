using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Models.JoinModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessServ = Heliondata.Services.ProcessService;

namespace Heliondata.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {

        private ProcessServ _processService;

        public ProcessController(ProcessServ processService)
        {
            _processService = processService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Process>> SaveProcess(ProcessDTO processDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                Process process = _processService.SaveProcess(processDTO).Result;
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
            var process = _processService.GetProcess(id);

            if (process == null)
            {
                return NotFound();
            }

            return Ok(process);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Process>>> GetAllProcess()
        {
            List<Process> process = _processService.GetAllProcess();

            if (process == null)
            {
                return NotFound();
            }

            return Ok(process);
        }
    }
}