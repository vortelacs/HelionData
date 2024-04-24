using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Repositories;

namespace Heliondata.Controllers
{
    public class RepresentativeController : CrudControllerBase<Representative, RepresentativeInfoDTO>
    {
        public RepresentativeController(IGenericRepository<Representative> RepresentativeRepository, IMapper mapper) : base(RepresentativeRepository, mapper) { }
    }
}