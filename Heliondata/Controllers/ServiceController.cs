using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;

namespace Heliondata.Controllers
{

    public class ServiceController : CrudControllerBase<Service, Service>
    {
        public ServiceController(HelionDBContext context, IMapper mapper) : base(context, mapper) { }
    }

}