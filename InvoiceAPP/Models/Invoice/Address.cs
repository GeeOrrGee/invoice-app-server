namespace InvoiceAPP.Models.Invoice;

public class Address
{
    public Address(string streetAddress, string city, string postCode, string country)
    {
        this.streetAddress = streetAddress;
        this.city          = city;
        this.postCode      = postCode;
        this.country       = country;
    }

    public string streetAddress { get; set; }
    public string city          { get; set; }
    public string postCode      { get; set; }
    public string country       { get; set; }
}