using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Heliondata.Controllers
{

    public class CompanyController : CrudControllerBase<Company, CompanyInfoDTO>
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyRepository _companyRepository;

        public CompanyController(HelionDBContext context, IMapper mapper, CompanyRepository companyRepository, ILogger<CompanyController> logger)
            : base(context, mapper)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        // GET: api/company/pfa
        [HttpGet("pfa")]
        public async Task<IActionResult> GetPFACompanies()
        {
            var pfAs = await _companyRepository.GetAllCompaniesOfType("PFA");
            var dtoList = _mapper.Map<List<CompanyInfoDTO>>(pfAs);
            return Ok(dtoList);
        }

        // GET: api/company/srl
        [HttpGet("srl")]
        public async Task<IActionResult> GetSRLCompanies()
        {
            var srls = await _companyRepository.GetAllCompaniesOfType("SRL");
            var dtoList = _mapper.Map<List<CompanyInfoDTO>>(srls);
            return Ok(dtoList);
        }


        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] CompanyInfoDTO companyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var company = _mapper.Map<Company>(companyDto);
                _logger.LogInformation($"Before saving - Company type: {company.GetType().Name}, CNP: {((PFA)company).CNP}, Activity: {((PFA)company).Activity}");
                var createdCompany = await _companyRepository.Add(company);
                var resultDto = _mapper.Map<CompanyInfoDTO>(createdCompany);
                return CreatedAtAction("GetCompany", new { id = createdCompany.ID }, resultDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the company.");
            }
        }
    }


}