using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceAPP.Models
{
    public class AdressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string streetAdress { get; set; }
        [Required]
        public string postCode { get;set; }

        public AdressEntity()
        {

        }

        public AdressEntity(string id, string country, string city, string streetAdress, string postCode)
        {
            Id = id;
            this.country = country;
            this.city = city;
            this.streetAdress = streetAdress;
            this.postCode = postCode;
        }
    }
}
