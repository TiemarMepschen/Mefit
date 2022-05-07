using AutoMapper;
using Mefit_API.DTOs.User;
using Mefit_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mefit_API.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserReadDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
