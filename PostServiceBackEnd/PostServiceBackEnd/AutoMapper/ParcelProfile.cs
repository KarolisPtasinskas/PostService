using AutoMapper;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Entities;

namespace PostServiceBackEnd.AutoMapper
{
    public class ParcelProfile : Profile
    {
        public ParcelProfile()
        {
            CreateMap<Parcel, ParcelGetAllDTO>();
            CreateMap<ParcelGetAllDTO, Parcel>().ForMember(dto => dto.Weight, opt => opt.MapFrom(src => int.Parse(src.Weight))).ForMember(dto => dto.ParcelMachineId, opt => opt.MapFrom(src => int.Parse(src.ParcelMachineId)));

            CreateMap<Parcel, ParcelPutDTO>();
            CreateMap<ParcelPutDTO, Parcel>().ForMember(dto => dto.Weight, opt => opt.MapFrom(src => int.Parse(src.Weight))).ForMember(dto => dto.ParcelMachineId, opt => opt.MapFrom(src => int.Parse(src.ParcelMachineId)));

            CreateMap<Parcel, ParcelPostDTO>();
            CreateMap<ParcelPostDTO, Parcel>().ForMember(dto => dto.Weight, opt => opt.MapFrom(src => int.Parse(src.Weight))).ForMember(dto => dto.ParcelMachineId, opt => opt.MapFrom(src => int.Parse(src.ParcelMachineId)));
        }
    }
}
