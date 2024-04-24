using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Repositories;

namespace Heliondata.Controllers
{

    public class EmployeeController : CrudControllerBase<Employee, EmployeeInfoDTO>
    {
        public EmployeeController(IGenericRepository<Employee> employeeRepository, IMapper mapper) : base(employeeRepository, mapper) { }
    }

}