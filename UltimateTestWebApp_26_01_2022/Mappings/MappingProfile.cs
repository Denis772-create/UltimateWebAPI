using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(dto => dto.FullAddress,
                    opt => opt.MapFrom(x => string.Concat(x.Country, x.Address)));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

            CreateMap<CompanyForUpdateDto, Company>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
