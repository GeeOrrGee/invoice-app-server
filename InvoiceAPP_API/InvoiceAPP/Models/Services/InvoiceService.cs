using InvoiceAPP.Models.DTO;
using InvoiceAPP.Models.Invoice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static InvoiceAPP.Models.InvoiceRepository;

namespace InvoiceAPP.Models
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        }
        
        private bool checkInvoiceIdType(string invoiceId)
        {
            int num_of_chars = Const.NUMBER_OF_CHARACTERS;
            for (int i = 0; i < num_of_chars; i++)
            {
                if (invoiceId[i] < Const.FROM_SYMBOL_FOR_CHARS || invoiceId[i] > Const.TO_SYMBOL_FOR_CHARS) return false;
            }
            
            for (int i = num_of_chars; i <invoiceId.Count(); i++)
            {
                if (invoiceId[i] < Const.FROM_SYMBOL_FOR_DIGIT || invoiceId[i] > Const.TO_SYMBOL_FOR_DIGIT) return false;
            }
            return true;
        }
        
        private bool checkAddressValidation(Address address)
        {
            //TODO:
            return true;
        }
        
        //Needs modife
        private bool checkClientInfo(CustomerInfo clientinfo)
        {
            //TODO;
            if (!checkAddressValidation(clientinfo.address)) return false;
            return true;
        }
    
        //Needs modife
        private bool validateInvoice(Invoice.Invoice invoice)
        {
            //TODO:
            if (invoice.invoiceId != "" || !checkAddressValidation(invoice.billFrom)) return false;
            if (invoice.status == Invoice.Invoice.Status.PAID ||
                (invoice.status != Invoice.Invoice.Status.DRAFT &&
                invoice.status != Invoice.Invoice.Status.PANDING)) return false;
            if (!checkClientInfo(invoice.billTo)) return false;
            return true;
        }
        
        public KeyValuePair<STATUS_CODE, Invoice.Invoice> newInvoice(Invoice.Invoice invoiceToCreate)
        {
            if (validateInvoice(invoiceToCreate))
            {
                _invoiceRepository.newInvoice(invoiceToCreate);
                return new KeyValuePair<STATUS_CODE, Invoice.Invoice>(
                    STATUS_CODE.OK, invoiceToCreate);
            }
            else
            {
                return new KeyValuePair<STATUS_CODE, Invoice.Invoice>(
                    STATUS_CODE.BAD_REQUEST, null);
            }

        }

        private bool checkInvoice(Invoice.Invoice invoice)
        {
            //TODO:
            return true;
        }

        public STATUS_CODE editInvoice(string invoiceId, Invoice.Invoice editedInvoice)
        {
            if (!checkInvoiceIdType(invoiceId) && checkInvoice(editedInvoice))
            {
                if (_invoiceRepository.editInvoice(invoiceId, editedInvoice))
                {
                    return STATUS_CODE.NO_CONTENT;
                }
                return STATUS_CODE.NOT_FOUND;
            }
            return STATUS_CODE.BAD_REQUEST;
        }
        
        //Need Modife
        public STATUS_CODE markAsPaid(string invoiceId)
        {
            if (checkInvoiceIdType(invoiceId))
            {
                if (_invoiceRepository.markAsPaid(invoiceId))
                {
                    return STATUS_CODE.NO_CONTENT;    
                }
                else
                {
                    return STATUS_CODE.NOT_FOUND;  
                }
            }
            return STATUS_CODE.BAD_REQUEST;
        }

        public STATUS_CODE deleteInvoice(string invoiceId)
        {
            if (checkInvoiceIdType(invoiceId))
            {
                if (_invoiceRepository.deleteInvoice(invoiceId))
                {
                    return STATUS_CODE.NO_CONTENT;    
                }
                return STATUS_CODE.NOT_FOUND;
            }
            return STATUS_CODE.BAD_REQUEST;
        }
        
        // This method needs modife       
        public KeyValuePair<STATUS_CODE, List<Invoice.Invoice> >  getInvoicesByOwnerId(string ownerId)
        {
            List < Invoice.Invoice > result= _invoiceRepository.getInvoicesByOwnerId(ownerId);
            if (result != null)
            {
                return new KeyValuePair<STATUS_CODE, List<Invoice.Invoice>>(STATUS_CODE.OK, result);
            }
            else
            {
                return new KeyValuePair<STATUS_CODE, List<Invoice.Invoice>>(STATUS_CODE.NOT_FOUND, null);
            }
        }
        
        // This method needs modife       
        public  KeyValuePair<STATUS_CODE, List<Invoice.Invoice> > getInvoicesByStatus(string ownerId, Invoice.Invoice.Status status)
        {
            if ((status == Invoice.Invoice.Status.PAID || status == Invoice.Invoice.Status.DRAFT ||
                 status == Invoice.Invoice.Status.PANDING))
            {
                List<Invoice.Invoice> result = _invoiceRepository.getInvoicesByStatus(ownerId, status);
                if (result != null)
                {
                    return new KeyValuePair<STATUS_CODE, List<Invoice.Invoice>>(
                        STATUS_CODE.OK, result);
                }
                else
                {
                    return new KeyValuePair<STATUS_CODE, List<Invoice.Invoice>>(
                        STATUS_CODE.NOT_FOUND, null);
                }
            }
            return new KeyValuePair<STATUS_CODE, List<Invoice.Invoice> >(STATUS_CODE.BAD_REQUEST, null);
        }

        public KeyValuePair<STATUS_CODE, Invoice.Invoice> getInvoiceByInvoiceId(string invoiceId)
        {
            if (checkInvoiceIdType(invoiceId))
            {
                Invoice.Invoice result = _invoiceRepository.getInvloiceByInvoiceId(invoiceId);
                if (result != null)
                {
                    return new KeyValuePair<STATUS_CODE, Invoice.Invoice>(
                        STATUS_CODE.OK, result);
                }
                return new KeyValuePair<STATUS_CODE, Invoice.Invoice>(
                    STATUS_CODE.NOT_FOUND, null);
            }
            else
            {
                return new KeyValuePair<STATUS_CODE, Invoice.Invoice>(
                    STATUS_CODE.BAD_REQUEST, null);
            }
        }
    }
}
