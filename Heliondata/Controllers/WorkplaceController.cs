using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Repositories;

namespace Heliondata.Controllers
{

    public class WorkplaceController : CrudControllerBase<Workplace, Workplace>
    {
        public WorkplaceController(IGenericRepository<Workplace> workplaceRepository, IMapper mapper) : base(workplaceRepository, mapper) { }
    }

}