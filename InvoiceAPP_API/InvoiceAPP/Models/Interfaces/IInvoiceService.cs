using InvoiceAPP.Models.DTO;

namespace InvoiceAPP.Models
{
    public interface IInvoiceService
    {
        bool  CreateInvoice(InvoiceDTO invoiceToCreate);
        InvoiceDTO?  GetInvoice(int invoiceId);
        List<InvoiceDTO>? GetInvoiceList(int fromUserId);
        bool DeleteInvoice(int invoiceId);
        bool UpdateInvoice(int invoiceId, double newAmount);
    }
}
