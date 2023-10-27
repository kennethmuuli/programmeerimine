namespace KooliProjekt.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public Booking? Booking { get; set; }
        public bool HadBooking { get; set; }
        public DateTime? OverdueTime { get; set; }
        public bool ReturnedLate { get; set; }
        public bool VehicleDamaged { get; set; }
    }
}
