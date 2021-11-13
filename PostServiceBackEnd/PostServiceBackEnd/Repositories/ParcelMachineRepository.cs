using Microsoft.EntityFrameworkCore;
using PostServiceBackEnd.Data;
using PostServiceBackEnd.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Repositories
{
    public class ParcelMachineRepository : IParcelMachineRepository<ParcelMachine>
    {
        private readonly DataContext _dataContext;

        public ParcelMachineRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ParcelMachine>> GetAllAsync()
        {
            return await _dataContext.ParcelMachines.OrderBy(pm => pm.IdentificationCode).ToListAsync();
        }

        public async Task AddAsync(ParcelMachine parcelMachine)
        {
            await _dataContext.ParcelMachines.AddAsync(parcelMachine);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<ParcelMachine> GetByIdAsync(int id)
        {
            return await _dataContext.ParcelMachines.AsNoTracking().FirstOrDefaultAsync(pm => pm.Id == id);
        }

        public async Task UpdateAsync(ParcelMachine parcelMachine)
        {
            _dataContext.ParcelMachines.Update(parcelMachine);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ParcelMachine parcelMachine)
        {
            _dataContext.Remove(parcelMachine);
            await _dataContext.SaveChangesAsync();
        }
    }
}
