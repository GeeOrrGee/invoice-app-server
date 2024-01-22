namespace InvoiceAPP.Models.Invoice;

public class Invoice
{
    public enum Status
    {
        DRAFT,
        PANDING,
        PAID
    }

    public Invoice(string invoiceId,  string ownerId, Address billFrom, CustomerInfo billTo, ProjectInfo projectInfo, List<Item> itemList, Status status)
    {
        this.invoiceId   = invoiceId;
        this.ownerId     = ownerId;
        this.billFrom    = billFrom;
        this.billTo      = billTo;
        this.projectInfo = projectInfo;
        this.itemList    = itemList;
        this.status      = status;
    }
    
    public string      ownerId { get; set; }
    public string      invoiceId { get; set; }
    public Address      billFrom { get; set; }
    public CustomerInfo billTo { get; set; }
    public ProjectInfo  projectInfo { get; set; }
    public List<Item>   itemList { get; set; }
    public Status       status { get; set; }
}