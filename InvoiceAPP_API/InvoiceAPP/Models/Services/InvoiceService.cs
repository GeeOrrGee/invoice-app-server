using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InvoiceAPP.Models
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        }
        
        protected bool ValidateInvoice(InvoiceDTO invoiceToValidate)
        {
            if (invoiceToValidate.FromUserID == 0)
                return false;
            if (invoiceToValidate.ToUserID == 0)
                return false;
            if (invoiceToValidate.InvoiceId  != 0)
                return false;
            if (invoiceToValidate.Amount <= 0)
                return false;
            return true;
        }

        public bool CreateInvoice(InvoiceDTO invoiceToCreate)
        {
            if (!ValidateInvoice(invoiceToCreate))
            {
                return false;
            }
            return _invoiceRepository.CreateInvoice(invoiceToCreate);
        }
        
        public InvoiceDTO? GetInvoice(int invoiceId)
        {
            try
            {
                var invoice =  _invoiceRepository.GetInvoice(invoiceId);
                return invoice;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invoice with this Id does not exist");
            }
        }

        public List<InvoiceDTO>? GetInvoiceList(int fromUserId)
        {
            try
            {
                return _invoiceRepository.GetInvoiceList(fromUserId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invoice with this UserId does not exist");
            }
        }
        
        public bool DeleteInvoice(int invoiceId)
        {
            try
            {
                return _invoiceRepository.DeleteInvoice(invoiceId);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateInvoice(int invoiceId, double newAmount)
        {
            try
            {
                _invoiceRepository.UpdateInvoice(invoiceId, newAmount);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invoice with this Id does not exist");
            }
            return true;
        }
    }
}
