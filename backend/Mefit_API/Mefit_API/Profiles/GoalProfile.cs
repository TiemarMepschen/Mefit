using Mefit_API.Models.Domain;
using Mefit_API.Models.DTOs.Goal;
using AutoMapper;
using System.Linq;

namespace Mefit_API.Profiles
{
    public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalCreateDTO>()
                .ReverseMap();
            CreateMap<Goal, GoalReadDTO>()
                .ForMember(gdto => gdto.CompletedWorkouts, opt => opt
                .MapFrom(w => w.Workouts.Select(p => p.Id).ToArray()))
                .ReverseMap();
            CreateMap<Goal, GoalUpdateDTO>()
                .ReverseMap();
        }
    }
}
