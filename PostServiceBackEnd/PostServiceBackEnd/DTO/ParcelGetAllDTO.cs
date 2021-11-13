using PostServiceBackEnd.Entities;

namespace PostServiceBackEnd.DTO
{
    public class ParcelGetAllDTO : ParcelDTO
    {
        public int Id { get; set; }
        public ParcelMachineDTO ParcelMachine { get; set; }
    }
}
