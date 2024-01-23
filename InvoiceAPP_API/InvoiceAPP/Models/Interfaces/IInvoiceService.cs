using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPP.Models
{
    public interface IInvoiceService
    {
        public enum STATUS_CODE
        {
            BAD_REQUEST,
            NOT_FOUND,
            OK,
            NO_CONTENT
        }
        public KeyValuePair<STATUS_CODE, Invoice.Invoice> newInvoice(Invoice.Invoice invoiceToCreate);
        public KeyValuePair<STATUS_CODE, Invoice.Invoice> editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public KeyValuePair<STATUS_CODE, Invoice.Invoice> markAsPaid(string invoiceId, Invoice.Invoice.Status newStatus);
        public KeyValuePair<STATUS_CODE, Invoice.Invoice> deleteInvoice(string invoiceId);
        public KeyValuePair<STATUS_CODE, List<Invoice.Invoice> >  getInvoicesByOwnerId(string ownerId);
        public  KeyValuePair<STATUS_CODE, List<Invoice.Invoice> > GetInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);
    }
}
