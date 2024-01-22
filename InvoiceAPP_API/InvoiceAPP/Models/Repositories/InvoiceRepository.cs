using InvoiceAPP.Data;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Http;


namespace InvoiceAPP.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {

        //private InvoiceStore _entities = new InvoiceStore();
        public InvoiceDTO? GetInvoice(int invoiceId)
        {
            foreach (var invoice in InvoiceStore.invoiceList)
            {
                if (invoice.InvoiceId == invoiceId)
                {
                    return invoice;
                }
            }

            return null;
            //throw new ArgumentException("Invoice with this Id does not exist!");
        }

        public List<InvoiceDTO> GetInvoiceList(int fromUserId)
        {
            List<InvoiceDTO> results = new List<InvoiceDTO>();

            foreach (var invoice in InvoiceStore.invoiceList)
            {
                if (invoice.FromUserID == fromUserId)
                {
                    results.Add(invoice);
                }
            }
            if (results.Any())
            {
                return results;
            }

            return null;
            //throw new ArgumentException("Invoices with this UserId does not exist!");
        }
        
        public bool CreateInvoice(InvoiceDTO invoiceToCreate)
        {
            try
            {
                invoiceToCreate.InvoiceId = InvoiceStore.invoiceList.OrderByDescending(u => u.InvoiceId).FirstOrDefault().InvoiceId + 1;
                InvoiceStore.invoiceList.Add(invoiceToCreate);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool DeleteInvoice(int invoiceId)
        {
            foreach (var invoice in InvoiceStore.invoiceList)
            {
                if (invoice.InvoiceId == invoiceId)
                {
                    InvoiceStore.invoiceList.Remove(invoice);
                    return true;
                }
            }

            return false;
        }
        
        public bool UpdateInvoice(int invoiceId, double newAmount)
        {
            try
            {
                foreach (var invoice in InvoiceStore.invoiceList)
                {
                    if (invoice.InvoiceId == invoiceId)
                    {
                        invoice.Amount = newAmount;       
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
