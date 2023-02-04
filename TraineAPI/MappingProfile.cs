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

            CreateMap<CommentDto, Comment>();

            CreateMap<CommentCreationDto, Comment>();

            CreateMap<CommentUpdateDto, Comment>();

            // Payment
            CreateMap<Payment, PaymentDto>();

            CreateMap<PaymentDto, Payment>();

            CreateMap<PaymentCreationDto, Payment>();

            CreateMap<PaymentUpdateDto, Payment>();


            //user
            CreateMap<User, userDto>();
            CreateMap<User, userloginDTO>();
            CreateMap<UserCreationDto, User>();
            CreateMap<UserUpdateDto, User>();


            //train
            CreateMap<Train, TrainDto>();
            CreateMap<Train, ConductorDto>();
            CreateMap<Train, DreiverDto>();
            CreateMap<TrainCreationDto,Train>();
            CreateMap<TrainUpdatenDto, Train>();

            //station
            CreateMap<Station, StationDto>();
            CreateMap<Station, StatioForOneTrainDto>();
            CreateMap<StationForCreateDto, Station>();
            CreateMap<StationForUpdateDto, Station>();

        }
    }
}
