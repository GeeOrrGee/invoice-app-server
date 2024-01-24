using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InvoiceAPP.Models.Invoice;

public class Invoice
{
    [Serializable]
    public enum Status
    {
        DRAFT,
        PANDING,
        PAID,
    }

    public Invoice()
    {
    }

    public Invoice(string invoiceId, string ownerId /*???*/, Address billFrom, CustomerInfo billTo,
        ProjectInfo projectInfo, List<Item> itemList, Status status)
    {
        this.invoiceId = invoiceId;
        this.ownerId = ownerId;
        this.billFrom = billFrom;
        this.billTo = billTo;
        this.projectInfo = projectInfo;
        this.itemList = itemList;
        this.status = status;
    }

    public string ownerId { get; set; }
    public string invoiceId { get; set; }
    public Address billFrom { get; set; }
    public CustomerInfo billTo { get; set; }
    public ProjectInfo projectInfo { get; set; }
    public List<Item> itemList { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public Status status { get; set; }

    public void transferData(Invoice invoice)
    {
        this.invoiceId   = invoice.invoiceId;
        this.billFrom    = invoice.billFrom;
        this.ownerId     = invoice.invoiceId;
        this.projectInfo = invoice.projectInfo;
        this.itemList    = invoice.itemList;
    }

}