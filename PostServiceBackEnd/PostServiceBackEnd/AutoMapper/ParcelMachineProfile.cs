using AutoMapper;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Entities;

namespace PostServiceBackEnd.AutoMapper
{
    public class ParcelMachineProfile : Profile
    {
        public ParcelMachineProfile()
        {
            CreateMap<ParcelMachine, ParcelMachineDTO>();

            CreateMap<ParcelMachine, ParcelMachineGetAllDTO>();
            CreateMap<ParcelMachineGetAllDTO, ParcelMachine>().ForMember(dto => dto.Capacity, opt => opt.MapFrom(src => int.Parse(src.Capacity)));


            CreateMap<ParcelMachine, ParcelMachinePostDTO>();
            CreateMap<ParcelMachinePostDTO, ParcelMachine>().ForMember(dto => dto.Capacity, opt => opt.MapFrom(src => int.Parse(src.Capacity)));


            CreateMap<ParcelMachine, ParcelMachinePutDTO>();
            CreateMap<ParcelMachinePutDTO, ParcelMachine>().ForMember(dto => dto.Capacity, opt => opt.MapFrom(src => int.Parse(src.Capacity)));
        }
    }
}
