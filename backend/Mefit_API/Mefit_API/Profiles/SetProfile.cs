using AutoMapper;
using Mefit_API.Models.Domain;
using Mefit_API.Models.DTOs.Set;

namespace Mefit_API.Profiles
{
    public class SetProfile : Profile
    {
        public SetProfile()
        {
            CreateMap<Set, SetReadDTO>()
                .ReverseMap();
        }
    }
}
