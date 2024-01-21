using InvoiceAPP.Models.DTO;

namespace InvoiceAPP.Models
{
    public interface IInvoiceService
    {
        bool CreateInvoice(InvoiceDTO invoiceToCreate);
        Task<InvoiceDTO>  GetInvoice(int id);
        IEnumerable<InvoiceDTO> GetInvoiceList(int userid);
        bool DeleteInvoice(int id);
        bool UpdateInvoice(int id, double newAmount);
    }
}
