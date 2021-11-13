using Microsoft.EntityFrameworkCore;
using PostServiceBackEnd.Entities;

namespace PostServiceBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ParcelMachine> ParcelMachines { get; set; }
        public DbSet<Parcel> Parcels { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
