using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                    options => options.MapFrom(x => string.Join(", ", x.Address,x.Country)));
        }

    }
}
