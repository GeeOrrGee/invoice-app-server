using InvoiceAPP.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvoiceAPP.Models
{
    public interface IInvoiceRepository
    {
        public InvoiceDTO GetInvoice(int invoiceId);
        public List<InvoiceDTO> GetInvoiceList(int fromUserId);
        public bool CreateInvoice(InvoiceDTO invoiceToCreate);
        public bool UpdateInvoice(int id, double newAmount);
        public bool DeleteInvoice(int invoiceId);
        
    }
}
