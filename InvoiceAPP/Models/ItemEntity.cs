using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceAPP.Models
{
    public class ItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Quantity { get;set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string invoiceID { get; set; }

        public ItemEntity()
        {
            
        }

        public ItemEntity(string iD, string name, string quantity, string price, string invoiceID)
        {
            ID = iD;
            Name = name;
            Quantity = quantity;
            Price = price;
            this.invoiceID = invoiceID;
        }
    }
}
