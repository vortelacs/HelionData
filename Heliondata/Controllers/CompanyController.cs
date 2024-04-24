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

        public CompanyController(IMapper mapper, CompanyRepository companyRepository, ILogger<CompanyController> logger)
            : base(companyRepository, mapper)
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
            Company company;
            if (companyDto.CNP.HasValue)
            {
                var pfa = new PFA();
                _mapper.Map(companyDto, pfa);
                company = pfa;
            }
            else if (companyDto.RegistrationCode.HasValue)
            {
                var srl = new SRL();
                _mapper.Map(companyDto, srl);
                company = srl;
            }
            else
            {
                company = new Company();
                _mapper.Map(companyDto, company);
            }
            int companyID = await _companyRepository.Add(company);
            return CreatedAtAction("Detail", new { id = companyID }, companyID);
        }
    }


}