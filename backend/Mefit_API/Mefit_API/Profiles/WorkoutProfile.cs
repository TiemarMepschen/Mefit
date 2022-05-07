using AutoMapper;
using Mefit_API.Models.Domain;
using Mefit_API.Models.DTOs.Workout;
using System.Linq;

namespace Mefit_API.Profiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutReadDTO>()
                .ForMember(wdto => wdto.Programmes, opt => opt
                .MapFrom(w => w.Programmes.Select(p => p.Id).ToArray()))
                .ForMember(wdto => wdto.CompletedInGoal, opt => opt 
                .MapFrom(w => w.Goals.Where(p => p.Completed == false).Select(p => p.Id).ToArray()))
                .ReverseMap();
        }
    }
}
