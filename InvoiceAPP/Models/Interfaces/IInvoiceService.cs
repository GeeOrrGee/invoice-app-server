namespace InvoiceAPP.Models
{
    public interface IInvoiceService
    {
   
        public Invoice.Invoice? newInvoice(Invoice.Invoice invoiceToCreate);
        public Invoice.Invoice? editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public Invoice.Invoice? markAsPaid(string invoiceId);
        public Invoice.Invoice deleteInvoice(string invoiceId);
        public List<Invoice.Invoice> getInvoicesByOwnerId(string ownerId);
        public  List<Invoice.Invoice> getInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);
        public Invoice.Invoice? getInvoiceByInvoiceId(string invoiceId);
    }
}
