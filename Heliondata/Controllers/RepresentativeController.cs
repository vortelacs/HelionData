using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;

namespace Heliondata.Controllers
{
    public class RepresentativeController : CrudControllerBase<Representative, RepresentativeInfoDTO>
    {
        public RepresentativeController(HelionDBContext context, IMapper mapper) : base(context, mapper) { }
    }
}