namespace KooliProjekt.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
    }
}
