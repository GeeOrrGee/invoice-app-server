namespace InvoiceAPP.Models.Invoice;

public class CustomerInfo
{
    public CustomerInfo(string name, string email, Address address)
    {
        this.name = name;
        this.email = email;
        this.address = address;
    }
    
    public string  name { get; set; }
    public string  email { get; set; }
    public Address address { get; set; }
}