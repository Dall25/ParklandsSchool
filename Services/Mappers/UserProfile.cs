using System;
using AutoMapper;
using Models.Entities;

namespace Services.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, User>().ReverseMap();
        }
    }
}

