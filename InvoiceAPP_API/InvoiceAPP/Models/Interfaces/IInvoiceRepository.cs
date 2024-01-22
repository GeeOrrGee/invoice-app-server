namespace InvoiceAPP.Models
{
    public interface IInvoiceRepository
    {
        public bool newInvoice(Invoice.Invoice invoiceToCreate);
        public bool editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public bool markAsPaid(string invoiceId, Invoice.Invoice.Status newStatus);
        public bool deleteInvoice(string invoiceId);
        public List<Invoice.Invoice> getInvoicesByOwnerId(string ownerId);
        public  List<Invoice.Invoice> GetInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);
    }
}
