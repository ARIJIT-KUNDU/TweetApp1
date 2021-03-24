using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.DTOs;
using TweetApp1.Entities;

namespace TweetApp1.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Tweet, TweetDto>();
            CreateMap<PasswordResetDto, AppUser>();
        }
    }
}
