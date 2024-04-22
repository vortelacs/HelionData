using AutoMapper;
using Heliondata.Models.DTO;

namespace Heliondata.Models.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyInfoDTO>();
            CreateMap<CompanyInfoDTO, Company>()
                .Include<CompanyInfoDTO, PFA>()
                .Include<CompanyInfoDTO, SRL>()
                .ConstructUsing(dto => DecideCompanyType(dto));

            CreateMap<CompanyInfoDTO, PFA>()
                .ForMember(dest => dest.CNP, opt => opt.MapFrom(src => src.CNP.Value))
                .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity));

            CreateMap<CompanyInfoDTO, SRL>()
                .ForMember(dest => dest.RegistrationCode, opt => opt.MapFrom(src => src.RegistrationCode.Value));

            CreateMap<Company, CompanyInfoDTO>();
            CreateMap<PFA, CompanyInfoDTO>()
                .ForMember(dto => dto.CNP, opt => opt.MapFrom(src => src.CNP))
                .ForMember(dto => dto.Activity, opt => opt.MapFrom(src => src.Activity))
                .ForMember(dto => dto.RegistrationCode, opt => opt.Ignore());

            CreateMap<SRL, CompanyInfoDTO>()
                .ForMember(dto => dto.RegistrationCode, opt => opt.MapFrom(src => src.RegistrationCode));
            CreateMap<Representative, RepresentativeInfoDTO>();
            CreateMap<Employee, EmployeeInfoDTO>();
        }

        private Company DecideCompanyType(CompanyInfoDTO dto)
        {

            if (dto.CNP.HasValue)
                return new PFA();
            else if (dto.RegistrationCode.HasValue)
                return new SRL();
            else
                return new Company();
        }
    }
}