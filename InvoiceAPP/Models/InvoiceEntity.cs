using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceAPP.Models
{
    public class InvoiceEntity
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("AdressEntity")]
        public string  billFromAddressID {  get; set; }
        [Required]
        public string clientName {  get; set; }
        [Required]
        public string clientEmail { get; set; }
        public int paymentTerm { get; set; }
        [ForeignKey("AdressEntity")]
        public string clientAdressID { get; set; }
        [Required]
        public DateTime createDate { get; set; }
        [Required]
        public string projectDescription { get;set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public AdressEntity AdressEntity { get; set; }

        public InvoiceEntity()
        {
         
        }

        public InvoiceEntity(int id, string invoiceID, string billfromadressid, string clientname, string clientemail, string cliendAdressid, DateTime createdate,string projectdescription,string status)
        {
            this.ID = invoiceID;
            this.billFromAddressID = billfromadressid;
            this.clientName = clientname;
            this.clientEmail = clientemail;
            this.clientAdressID = cliendAdressid;
            this.createDate = createdate;
            this.projectDescription = projectdescription;
            this.Status = status;
        }
    }
}
