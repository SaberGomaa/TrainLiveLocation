using AutoMapper;
using Entites;
using Shared.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace TraineAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            // Admin
            CreateMap<Admin, AdminDto>();

            CreateMap<AdminCreationDto, Admin>();

            CreateMap<AdminUpdateDto, Admin>();


            // Comment
            CreateMap<Comment, CommentDto>();

            CreateMap<CommentCreationDto, Comment>();

            CreateMap<CommentUpdateDto, Comment>();


            //user
            CreateMap<User, userDto>();
            CreateMap<UserCreationDto, User>();
            CreateMap<UserUpdateDto, User>();


            //train
           CreateMap<Train, TrainDto>();
           CreateMap<TrainCreationDto,Train>();
           CreateMap<TrainUpdatenDto, Train>();

        }
    }
}
