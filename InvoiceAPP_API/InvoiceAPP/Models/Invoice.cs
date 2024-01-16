namespace InvoiceAPP.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }
       public string PayTo { get; set; }
        public DateTime LaunchDate { get; set; }

    }
}
