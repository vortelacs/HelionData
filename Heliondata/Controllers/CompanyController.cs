using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;

namespace Heliondata.Controllers
{

    public class CompanyController : CrudControllerBase<Company, CompanyInfoDTO>
    {
        public CompanyController(HelionDBContext context, IMapper mapper) : base(context, mapper) { }
    }

}