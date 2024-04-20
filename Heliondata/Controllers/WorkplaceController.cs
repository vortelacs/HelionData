using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;

namespace Heliondata.Controllers
{

    public class WorkplaceController : CrudControllerBase<Workplace, Workplace>
    {
        public WorkplaceController(HelionDBContext context, IMapper mapper) : base(context, mapper) { }
    }

}