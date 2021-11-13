namespace PostServiceBackEnd.Filters
{
    public class ParcelFilter
    {
        public int ParcelMachineId { get; set; }

        public bool ValidId => ParcelMachineId > 0;
    }
}
