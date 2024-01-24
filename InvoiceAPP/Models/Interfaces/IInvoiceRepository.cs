using System.Security.Cryptography.X509Certificates;

namespace InvoiceAPP.Models
{
    public interface IInvoiceRepository
    {
        public bool newInvoice(Invoice.Invoice invoiceToCreate);
        public bool editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public bool markAsPaid(string invoiceId);
        public bool deleteInvoice(string invoiceId);
        public List<Invoice.Invoice> getInvoicesByOwnerId(string ownerId);
        public  List<Invoice.Invoice>? getInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);

         Invoice.Invoice? getInvloiceByInvoiceId(string invoiceId);
    }
}
