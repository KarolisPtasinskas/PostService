using Microsoft.EntityFrameworkCore;
using PostServiceBackEnd.Data;
using PostServiceBackEnd.Entities;
using PostServiceBackEnd.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Repositories
{
    public class ParcelRepository : IParcelRepository<Parcel>
    {
        private readonly DataContext _dataContext;

        public ParcelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _dataContext.Parcels.OrderBy(p => p.Weight).Include(pm => pm.ParcelMachine).ToListAsync();
        }

        public async Task<List<Parcel>> GetAllFilteredAsync(ParcelFilter parcelFilter)
        {
            return await _dataContext.Parcels.Where(p => p.ParcelMachineId == parcelFilter.ParcelMachineId).OrderBy(n => n.Weight).Include(pm => pm.ParcelMachine).ToListAsync();
        }

        public async Task AddAsync(Parcel parcel)
        {
            await _dataContext.Parcels.AddAsync(parcel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            return await _dataContext.Parcels.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _dataContext.Parcels.Update(parcel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parcel parcel)
        {
            _dataContext.Remove(parcel);
            await _dataContext.SaveChangesAsync();
        }
    }
}
