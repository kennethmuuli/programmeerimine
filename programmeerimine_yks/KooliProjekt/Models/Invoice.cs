namespace KooliProjekt.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public Rental Rental { get; set; }
        public decimal RentalPayable { get; set; }
        public decimal OverduePayable { get; set; }
        public decimal DamagesPayable { get; set; }
        public decimal TotalPayable { get; set; }
        public bool IsPaid { get; set; }
    }
}
