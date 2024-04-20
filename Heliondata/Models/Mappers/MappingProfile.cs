using AutoMapper;
using Heliondata.Models.DTO;

namespace Heliondata.Models.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Company, CompanyInfoDTO>()
                .ForMember(dest => dest.Representatives, opt => opt.MapFrom(src => src.Representatives.Select(r => r.ID)));

            CreateMap<Representative, RepresentativeInfoDTO>();
            CreateMap<Employee, EmployeeInfoDTO>();
        }
    }
}