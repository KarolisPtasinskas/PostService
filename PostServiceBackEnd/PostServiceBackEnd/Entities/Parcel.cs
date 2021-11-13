namespace PostServiceBackEnd.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int? ParcelMachineId { get; set; }
        public ParcelMachine ParcelMachine { get; set; }
    }
}
