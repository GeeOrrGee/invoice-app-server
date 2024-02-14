using System.ComponentModel.DataAnnotations;

namespace InvoiceAPP.Models
{
    public class InvoiceEntity
    {
        [Key]

        public int ID { get; set; }
        [Required]
        public string invoiceID { get; set; }
        [Required]
        public int  billFromAddressID {  get; set; }
        [Required]
        public string clientName {  get; set; }
        [Required]
        public string clientEmail { get; set; }
        [Required]
        public int clientAdressID { get; set; }
        [Required]
        public DateTime createDate { get; set; }
        [Required]
        public string projectDescription { get;set; }
        [Required]
        public string Status { get; set; }

        public InvoiceEntity()
        {

        }

        public InvoiceEntity(int id, string invoiceID, int billfromadressid, string clientname, string clientemail, int cliendAdressid, DateTime createdate,string projectdescription,string status)
        {
            this.ID = id;
            this.invoiceID = invoiceID;
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
