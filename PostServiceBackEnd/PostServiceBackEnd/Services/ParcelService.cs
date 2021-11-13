using AutoMapper;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Entities;
using PostServiceBackEnd.Filters;
using PostServiceBackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Services
{
    public class ParcelService
    {
        private readonly IParcelRepository<Parcel> _parcelRepository;
        private readonly IMapper _mapper;

        public ParcelService(IParcelRepository<Parcel> parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<List<ParcelGetAllDTO>> GetAllAsync(ParcelFilter parcelFilter)
        {
            if (!parcelFilter.ValidId)
            {
                var parcelsFromDb = await _parcelRepository.GetAllAsync();
                return _mapper.Map<List<ParcelGetAllDTO>>(parcelsFromDb);
            }

            var filteredParcelsFromDb = await _parcelRepository.GetAllFilteredAsync(parcelFilter);
            return _mapper.Map<List<ParcelGetAllDTO>>(filteredParcelsFromDb);
        }

        public async Task AddAsync(ParcelPostDTO parcel)
        {
            var parcelToDb = _mapper.Map<Parcel>(parcel);
            await _parcelRepository.AddAsync(parcelToDb);
        }

        public async Task<ParcelPutDTO> GetByIdAsync(int id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id);

            if (parcel == null)
            {
                throw new ArgumentException("Parcel does't exist.");
            }

            return _mapper.Map<ParcelPutDTO>(parcel);
        }

        public async Task UpdateAsync(ParcelPutDTO parcel)
        {
            var parcelInDb = await _parcelRepository.GetByIdAsync(parcel.Id);

            if (parcelInDb == null)
            {
                throw new ArgumentException("Parcel does't exist.");
            }

            var parcelToDb = _mapper.Map<Parcel>(parcel);
            await _parcelRepository.UpdateAsync(parcelToDb);
        }

        public async Task Delete(int id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id);

            if (parcel == null)
            {
                throw new ArgumentException("Parcel does't exist.");
            }

            await _parcelRepository.DeleteAsync(parcel);

        }
    }
}
