namespace InvoiceAPP.Models.DTO
{
    public class InvoiceDTO
    {
        public string InvoiceId { get; set; }
        public AddressDTO billFromAddress { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public AddressDTO ClientAddress { get; set; }
        public DateTime CreateTime { get; set; }
        public int PaymentTerm { get; set; }
        public string ProjectDescription { get; set; }
        public List<ItemDTO> Items { get; set; }
        public string Status { get; set; }
    }
}
