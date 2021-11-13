namespace PostServiceBackEnd.Entities
{
    public class ParcelMachine
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string IdentificationCode { get; set; }
    }
}
