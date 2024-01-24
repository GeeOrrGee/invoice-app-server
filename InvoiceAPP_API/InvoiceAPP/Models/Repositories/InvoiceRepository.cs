using InvoiceAPP.Data;

namespace InvoiceAPP.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {
        
        private static string GenerateRandomSymbols(int length, char symbolsFrom, char symbolsTo)
        {
            Random random = new Random();
            string symbols = "";
            for (int i = 0; i < length; i++)
            {
                char randomDigit = (char)random.Next(symbolsFrom, symbolsTo + 1);
                symbols += randomDigit;
            }
            return symbols;
        }
        
        static string GenerateString()
        {
            string uppercaseChars = GenerateRandomSymbols(Const.NUMBER_OF_CHARACTERS, Const.FROM_SYMBOL_FOR_CHARS, Const.TO_SYMBOL_FOR_CHARS);
         
            string digits = GenerateRandomSymbols(Const.NUMBER_OF_DIGITS, Const.FROM_SYMBOL_FOR_DIGIT, Const.TO_SYMBOL_FOR_DIGIT);
            
            string result = uppercaseChars + digits;

            return result;
        }

        private static bool checkingGeneratedString(string generatedString)
        {
            foreach (var invoice in Data.InvoiceStore.invoiceList)
            {
                if (generatedString == invoice.invoiceId) return false;
            }
            return true;
        }

        private string generateNewInvoiceId()
        {
            string newPossibleInvoiceId;
            while (true)
            {
                newPossibleInvoiceId = GenerateString();
                if (checkingGeneratedString(newPossibleInvoiceId)) break;
            }
            return newPossibleInvoiceId;
        }
        public bool newInvoice(Invoice.Invoice invoiceToCreate)
        {
                invoiceToCreate.invoiceId = generateNewInvoiceId();
                InvoiceStore.invoiceList.Add(invoiceToCreate);
                return true;
        }

        public bool editInvoice(string invoiceId, Invoice.Invoice editedInvoice)
        {
            for (int i = 0; i < InvoiceStore.invoiceList.Count(); i++)
            {
                if (InvoiceStore.invoiceList[i].invoiceId == invoiceId)
                {
                    InvoiceStore.invoiceList[i] = editedInvoice;
                    return true;
                }
            }
            
            return false;
        }

        public bool markAsPaid(string invoiceId)
        {
            for (int i = 0; i < InvoiceStore.invoiceList.Count(); i++)
            {
                if (InvoiceStore.invoiceList[i].invoiceId == invoiceId && InvoiceStore.invoiceList[i].status == Invoice.Invoice.Status.PANDING)
                {
                    InvoiceStore.invoiceList[i].status = Invoice.Invoice.Status.PAID;
                    return true;
                }
            }
            
            return false;
        }

        public bool deleteInvoice(string invoiceId)
        {
            foreach (var invoice in InvoiceStore.invoiceList)
            {
                if (invoice.invoiceId == invoiceId)
                {
                    InvoiceStore.invoiceList.Remove(invoice);
                    return true;
                }
            }
            
            return false;
        }
        
        public List<Invoice.Invoice> getInvoicesByOwnerId(string ownerId)
        {
            List<Invoice.Invoice> invoices = new List<Invoice.Invoice>();
            for (int i = 0; i < InvoiceStore.invoiceList.Count(); i++)
            {
                if (InvoiceStore.invoiceList[i].ownerId == ownerId)
                {
                    invoices.Add(InvoiceStore.invoiceList[i]);
                }
            }
            if (invoices.Any()) return invoices;
            return null;
        }

        public List<Invoice.Invoice> getInvoicesByStatus(string ownerId, Invoice.Invoice.Status status)
        {
            List<Invoice.Invoice> invoices = new List<Invoice.Invoice>();
            for (int i = 0; i < InvoiceStore.invoiceList.Count(); i++)
            {
                if (InvoiceStore.invoiceList[i].ownerId == ownerId && InvoiceStore.invoiceList[i].status == status)
                {
                    invoices.Add(InvoiceStore.invoiceList[i]);
                }
            }
            if (invoices.Any())  return invoices;
            return null;
        }

        public Invoice.Invoice? getInvloiceByInvoiceId(string invoiceId)
        {
            for (int i = 0; i < Data.InvoiceStore.invoiceList.Count(); i++)
            {
                if (Data.InvoiceStore.invoiceList[i].invoiceId == invoiceId)
                {
                    return InvoiceStore.invoiceList[i];
                }
            }
            return null;
        }
    }
}
