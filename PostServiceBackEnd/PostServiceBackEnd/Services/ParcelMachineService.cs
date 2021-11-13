using AutoMapper;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Entities;
using PostServiceBackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Services
{
    public class ParcelMachineService
    {
        private readonly IParcelMachineRepository<ParcelMachine> _parcelMachineRepository;
        private readonly IMapper _mapper;

        public ParcelMachineService(IParcelMachineRepository<ParcelMachine> parcelMachineRepository, IMapper mapper)
        {
            _parcelMachineRepository = parcelMachineRepository;
            _mapper = mapper;
        }

        public async Task<List<ParcelMachineGetAllDTO>> GetAllAsync()
        {
            var parcelMachinesFromDb = await _parcelMachineRepository.GetAllAsync();
            return _mapper.Map<List<ParcelMachineGetAllDTO>>(parcelMachinesFromDb);
        }
        public async Task AddAsync(ParcelMachinePostDTO parcelMachine)
        {
            var parcelMachineToDb = _mapper.Map<ParcelMachine>(parcelMachine);
            await _parcelMachineRepository.AddAsync(parcelMachineToDb);
        }

        public async Task<ParcelMachinePutDTO> GetByIdAsync(int id)
        {
            var parcelMachine = await _parcelMachineRepository.GetByIdAsync(id);

            if (parcelMachine == null)
            {
                throw new ArgumentException("Parcel machine does't exist.");
            }

            return _mapper.Map<ParcelMachinePutDTO>(parcelMachine);
        }

        public async Task UpdateAsync(ParcelMachinePutDTO parcelMachine)
        {
            var parcelMachineInDb = await _parcelMachineRepository.GetByIdAsync(parcelMachine.Id);

            if (parcelMachineInDb == null)
            {
                throw new ArgumentException("Parcel machine does't exist.");
            }

            var parcelMachineToDb = _mapper.Map<ParcelMachine>(parcelMachine);
            await _parcelMachineRepository.UpdateAsync(parcelMachineToDb);
        }

        public async Task Delete(int id)
        {
            var parcelMachine = await _parcelMachineRepository.GetByIdAsync(id);

            if (parcelMachine == null)
            {
                throw new ArgumentException("Parcel machine does't exist.");
            }

            await _parcelMachineRepository.DeleteAsync(parcelMachine);
        }
    }
}
