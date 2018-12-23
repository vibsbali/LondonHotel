using AutoMapper;
using LondonHotel.Api.Models;

namespace LondonHotel.Api.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100m))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                    Link.To(nameof(Controllers.RoomsController.GetRoomById), new {roomId = src.Id})));

        }
    }
}
