using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPP.Models
{
    public interface IInvoiceService
    {
        public ActionResult<Invoice.Invoice> newInvoice(Invoice.Invoice invoiceToCreate);
        public IActionResult editInvoice(string invoiceId, Invoice.Invoice editedInvoice);
        public IActionResult markAsPaid(string invoiceId, Invoice.Invoice.Status newStatus);
        public IActionResult deleteInvoice(string invoiceId);
        public ActionResult<List<Invoice.Invoice> > getInvoicesByOwnerId(string ownerId);
        public  ActionResult<List<Invoice.Invoice> > GetInvoicesByStatus(string ownwerId, Invoice.Invoice.Status status);
    }
}
