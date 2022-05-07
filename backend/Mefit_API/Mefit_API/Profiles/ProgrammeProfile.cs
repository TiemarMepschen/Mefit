using AutoMapper;
using Mefit_API.Models.Domain;
using Mefit_API.Models.DTOs.Programme;
using System.Linq;

namespace Mefit_API.Profiles
{
    public class ProgrammeProfile : Profile
    {
        public ProgrammeProfile()
        {
            CreateMap<Programme, ProgrammeReadDTO>()
                .ForMember(pdto => pdto.Workouts, opt => opt
                .MapFrom(p => p.Workouts.Select(w => w.Id).ToArray()))
                .ReverseMap();
        }
    }
}
