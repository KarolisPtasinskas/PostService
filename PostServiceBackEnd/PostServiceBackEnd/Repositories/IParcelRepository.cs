using PostServiceBackEnd.Entities;
using PostServiceBackEnd.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Repositories
{
    public interface IParcelRepository<T> where T : class
    {
        Task AddAsync(Parcel parcel);
        Task DeleteAsync(Parcel parcel);
        Task<List<Parcel>> GetAllAsync();
        Task<List<Parcel>> GetAllFilteredAsync(ParcelFilter parcelFilter);
        Task<Parcel> GetByIdAsync(int id);
        Task UpdateAsync(Parcel parcel);
    }
}