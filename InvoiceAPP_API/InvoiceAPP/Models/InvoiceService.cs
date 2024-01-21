using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InvoiceAPP.Models
{
    public class InvoiceService : IInvoiceService
    {
        private InvoiceRepository _invoicerepository;
        private ModelStateDictionary _modelState;
        public InvoiceService(InvoiceRepository invoicerepository, ModelStateDictionary modelstate)
        {
            _invoicerepository = invoicerepository;
            _modelState = modelstate;
        }
        protected bool ValidateInvoice(InvoiceDTO invoiceToValidate)
        {
            if (invoiceToValidate.payToName.Trim().Length == 0)
                _modelState.AddModelError("payToName", "payToName is required");
            if (invoiceToValidate.payToName.Trim().Length == 0)
                _modelState.AddModelError("payToSurName", "payToSurName is required");
            if (invoiceToValidate.Id != 0)
                _modelState.AddModelError("Id", "ID has to be zero");
            if (invoiceToValidate.Amount <= 0)
                _modelState.AddModelError("Amount", "Amount can not be less than a zero or a zero");
            if (invoiceToValidate.UserID == 0)
                _modelState.AddModelError("UserID", "UserId can not be zero");
            return _modelState.IsValid;
        }

        public async Task<IEnumerable<InvoiceDTO>> ListInvoices()
        {
            var result = await _invoicerepository.InvoiceList();
            return result;
        }
        public bool CreateInvoice(InvoiceDTO invoiceToCreate)
        {
            if (!ValidateInvoice(invoiceToCreate))
            {
                return false;
            }
            try
            {
                _invoicerepository.CreateInvoice(invoiceToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteInvoice(int id)
        {
            try
            {
                _invoicerepository.DeleteInvoice(id);
            }
            catch (Exception ex)
            {
                _modelState.AddModelError("DeleteInvoice", $"Error deleting invoice wirth ID {id} : {ex.Message}");
                return false;
            }
            return true;
        }

        public async Task<InvoiceDTO> GetInvoice(int id)
        {
            try
            {
                var invoice = await _invoicerepository.GetInvoice(id);
                return invoice;
            }
            catch (Exception ex)
            {
                _modelState.AddModelError("GetInvoice", $"Error gettint invoice with ID {id} : {ex.Message}");
                throw new ArgumentException("Invoice with this Id does not exist");
            }
        }

        public IEnumerable<InvoiceDTO> GetInvoiceList(int userid)
        {
            try
            {
                return _invoicerepository.GetInvoiceList(userid);
            }
            catch (Exception ex)
            {
                _modelState.AddModelError("GetInvoiceList", $"Error gettint invoices with UserID {userid} : {ex.Message}");
                throw new ArgumentException("Invoice with this UserId does not exist");
            }
        }

        public bool UpdateInvoice(int id, double newAmount)
        {
            try
            {
                _invoicerepository.UpdateInvoice(id, newAmount);
            }
            catch (Exception ex)
            {
                _modelState.AddModelError("UpdateInvoice", $"Error gettint invoice with ID {id} : {ex.Message}");
                throw new ArgumentException("Invoice with this Id does not exist");
            }
            return true;
        }
    }
}
