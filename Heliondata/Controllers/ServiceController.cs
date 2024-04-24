using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Repositories;

namespace Heliondata.Controllers
{

    public class ServiceController : CrudControllerBase<Service, Service>
    {
        public ServiceController(IGenericRepository<Service> serviceRepository, IMapper mapper) : base(serviceRepository, mapper) { }
    }

}