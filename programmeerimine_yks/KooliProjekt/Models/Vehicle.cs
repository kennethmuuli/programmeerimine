namespace KooliProjekt.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public VehicleType Type { get; set; }
        public string LicencePlateNumber { get; set; }
        public int OdometerRead { get; set; }

        public float PricePerHour { get; set; }
        public float Deposit { get; set; }
        public float OverduePricePerHour { get; set; }
        public bool Booked { get; set; }
    }
}
