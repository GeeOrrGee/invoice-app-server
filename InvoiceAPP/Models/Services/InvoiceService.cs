using InvoiceAPP.Models.Invoice;

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

        private Invoice.Invoice uninitializedInvoice()
        {
            Invoice.Invoice invoice = new Invoice.Invoice();
            invoice.status = Invoice.Invoice.Status.UNINITIALIZED;
            return invoice;
        }

        private List<Invoice.Invoice> emptyInvoiceList()
        {
            List<Invoice.Invoice> emptyList = new List<Invoice.Invoice>();
            return emptyList;
        }
        
        public Invoice.Invoice? newInvoice(Invoice.Invoice invoiceToCreate)
        {
            if (validateInvoice(invoiceToCreate))
            {
                _invoiceRepository.newInvoice(invoiceToCreate);
                return invoiceToCreate;
            }
            else
            {
                return null;
            }
        }

        private bool checkInvoice(Invoice.Invoice invoice)
        {
            //TODO:
            return true;
        }
        
        public Invoice.Invoice? editInvoice(string invoiceId, Invoice.Invoice editedInvoice)
        {
            if (!checkInvoiceIdType(invoiceId) && checkInvoice(editedInvoice))
            {
                if (_invoiceRepository.editInvoice(invoiceId, editedInvoice))
                {
                    return editedInvoice;
                }
                
            }
            return uninitializedInvoice();
        }
        
        //Needs Modife
        public Invoice.Invoice? markAsPaid(string invoiceId)
        {
            if (checkInvoiceIdType(invoiceId))
            {
                if (_invoiceRepository.markAsPaid(invoiceId))
                {
                    return _invoiceRepository.getInvloiceByInvoiceId(invoiceId);    
                }
                else
                {
                    return uninitializedInvoice();  
                }
            }
            return null;
        }
        

        //დასაწერია
        public Invoice.Invoice? deleteInvoice(string invoiceId)
        {
            if (checkInvoiceIdType(invoiceId))
            {
                Invoice.Invoice? invoice = _invoiceRepository.deleteInvoice(invoiceId); 
                if (invoice != null)
                {
                    return invoice;    
                }
                return uninitializedInvoice();
            }
            return null;
        }
        
        // This method needs modife       
        public List<Invoice.Invoice> getInvoicesByOwnerId(string ownerId)
        {
            List < Invoice.Invoice > result= _invoiceRepository.getInvoicesByOwnerId(ownerId);
            if (result != null)
            {
                return result;
            }
            else
            {
                return emptyInvoiceList();
            }
        }
        
        // This method needs modife       
        public  List<Invoice.Invoice>?  getInvoicesByStatus(string ownerId, Invoice.Invoice.Status status)
        {
            if ((status == Invoice.Invoice.Status.PAID || status == Invoice.Invoice.Status.DRAFT ||
                 status == Invoice.Invoice.Status.PANDING))
            {
                List<Invoice.Invoice> result = _invoiceRepository.getInvoicesByStatus(ownerId, status);
                return result;
            }
            return null;
        }
        
        public Invoice.Invoice? getInvoiceByInvoiceId(string invoiceId)
        {
            if (checkInvoiceIdType(invoiceId))
            {
                Invoice.Invoice result = _invoiceRepository.getInvloiceByInvoiceId(invoiceId);
                if (result != null)
                {
                    return result;
                }
                return uninitializedInvoice();
            }
            else
            {
                return null;
            }
        }
    }
}
