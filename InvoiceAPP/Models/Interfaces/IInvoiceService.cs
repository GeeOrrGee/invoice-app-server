namespace InvoiceAPP.Models
{
    public interface IInvoiceService
    {
   
        public KeyValuePair<STATUS_CODE, Invoice.Invoice> newInvoice(Invoice.Invoice invoiceToCreate);
        public STATUS_CODE editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public STATUS_CODE markAsPaid(string invoiceId);
        public STATUS_CODE deleteInvoice(string invoiceId);
        public KeyValuePair<STATUS_CODE, List<Invoice.Invoice> >  getInvoicesByOwnerId(string ownerId);
        public  KeyValuePair<STATUS_CODE, List<Invoice.Invoice> > getInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);
        KeyValuePair<STATUS_CODE, Invoice.Invoice> getInvoiceByInvoiceId(string invoiceId);
    }
}
