using System.ComponentModel.DataAnnotations;

namespace InvoiceAPP.Models.DTO
{
    public class InvoiceDTO
    {
        public int    InvoiceId { get; set; }
        public int    FromUserID { get; set; }
        public int    ToUserID { get; set; }
        public double Amount { get; set; }
    }
}
