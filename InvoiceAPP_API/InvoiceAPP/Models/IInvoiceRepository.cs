using InvoiceAPP.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvoiceAPP.Models
{
    public interface IInvoiceRepository
    {
        bool CreateInvoice(InvoiceDTO invoiceToCreate);
        Task< InvoiceDTO> GetInvoice(int id);
        IEnumerable<InvoiceDTO> GetInvoiceList(int userid);
        bool DeleteInvoice(int id);
        bool UpdateInvoice(int id, double newAmount);
    }
}
