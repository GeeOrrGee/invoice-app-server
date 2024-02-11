using System.Security.Cryptography.X509Certificates;

namespace InvoiceAPP.Models
{
    public interface IInvoiceRepository
    {
        public bool newInvoice(Invoice.Invoice invoiceToCreate);
        public bool editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public bool markAsPaid(string invoiceId);
        public Invoice.Invoice? deleteInvoice(string invoiceId);
        public List<Invoice.Invoice> getInvoicesByOwnerId(string ownerId);
        public  List<Invoice.Invoice>? getInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);
        public Invoice.Invoice? getInvloiceByInvoiceId(string invoiceId);
    }
}
