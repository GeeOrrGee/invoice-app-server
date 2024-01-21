using InvoiceAPP.Data;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Http;


namespace InvoiceAPP.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {

        //private InvoiceStore _entities = new InvoiceStore();

        public async Task<IEnumerable<InvoiceDTO>> InvoiceList()
        {
            return await Task.Run(() => InvoiceStore.invoiceList);
        }

        public bool CreateInvoice(InvoiceDTO invoiceToCreate)
        {
            try
            {
                invoiceToCreate.Id = InvoiceStore.invoiceList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
                InvoiceStore.invoiceList.Add(invoiceToCreate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInvoice(int id)
        {
            try
            {
                foreach (var invoice in InvoiceStore.invoiceList)
                {
                    if (invoice.Id == id)
                    {
                        InvoiceStore.invoiceList.Remove(invoice);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InvoiceDTO> GetInvoice(int id)
        {
            foreach (var invoice in InvoiceStore.invoiceList)
            {
                if (invoice.Id == id)
                {
                    return invoice;
                }
            }
            throw new ArgumentException("Invoice with this Id does not exist!");
        }

        public IEnumerable<InvoiceDTO> GetInvoiceList(int userid)
        {
            List<InvoiceDTO> results = new List<InvoiceDTO>();

            foreach (var invoice in InvoiceStore.invoiceList)
            {
                if (invoice.UserID == userid)
                {
                    results.Add(invoice);
                }
            }
            if (results.Any())
            {
                return results;
            }
            throw new ArgumentException("Invoices with this UserId does not exist!");
        }

        public bool UpdateInvoice(int id, double newAmount)
        {
            try
            {
                foreach (var invoice in InvoiceStore.invoiceList)
                {
                    if (invoice.Id == id)
                    {
                        invoice.Amount = newAmount;                      
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
