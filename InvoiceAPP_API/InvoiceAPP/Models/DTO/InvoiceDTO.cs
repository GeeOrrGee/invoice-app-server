using System.ComponentModel.DataAnnotations;

namespace InvoiceAPP.Models.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        [Required]
        [MaxLength(30)]
        public string payToName { get; set; }

        [Required]
        [MaxLength(30)]
        public string payToSurName { get; set; }
    }
}
