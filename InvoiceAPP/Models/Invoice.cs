namespace InvoiceAPP.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }
       public string payToName { get; set; }
        public string payToSurName { get; set; }

        public DateTime LaunchDate { get; set; }

    }
}
