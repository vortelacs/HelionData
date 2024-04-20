using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;

namespace Heliondata.Controllers
{

    public class EmployeeController : CrudControllerBase<Employee, EmployeeInfoDTO>
    {
        public EmployeeController(HelionDBContext context, IMapper mapper) : base(context, mapper) { }
    }

}