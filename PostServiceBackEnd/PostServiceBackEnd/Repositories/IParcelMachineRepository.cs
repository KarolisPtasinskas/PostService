using PostServiceBackEnd.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Repositories
{
    public interface IParcelMachineRepository<T> where T : class
    {
        Task AddAsync(ParcelMachine parcelMachine);
        Task DeleteAsync(ParcelMachine parcelMachine);
        Task<List<ParcelMachine>> GetAllAsync();
        Task<ParcelMachine> GetByIdAsync(int id);
        Task UpdateAsync(ParcelMachine parcelMachine);
    }
}