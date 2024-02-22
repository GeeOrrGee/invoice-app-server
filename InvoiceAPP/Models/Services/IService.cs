using InvoiceAPP.Models.DTO;

namespace InvoiceAPP.Models.Services
{
    public interface IService
    {
       InvoiceDTO GetinvoiceID(string invoiceID);
        IEnumerable<InvoiceDTO>  GetinvoiceList();
        IEnumerable<InvoiceDTO> GetinvoiceListByStatus(string status);
        bool CreateDraft(InvoiceDTO invoiceDTO);
        bool CreatePending(InvoiceDTO invoiceDTO);
        bool MarkAsPaid(string invoiceid);
        void UpdateInvoice(InvoiceDTO invoiceDTO);
        void DeleteInvoice(string invoiceID);
    }
}
