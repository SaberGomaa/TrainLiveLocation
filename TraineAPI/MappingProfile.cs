using AutoMapper;
using Entites;
using Shared.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TraineAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Admin, AdminDto>();

            CreateMap<AdminCreationDto, Admin>();

        }
    }
}
