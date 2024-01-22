using InvoiceAPP.Data;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Http;


namespace InvoiceAPP.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private const int NUMBER_OF_DIGITS = 4;
        private const int NUMBER_OF_CHARACTERS = 2;
        static string GenerateString()
        {
            string uppercaseChars = GenerateRandomUppercase(NUMBER_OF_CHARACTERS);
         
            string digits = GenerateRandomDigits(NUMBER_OF_DIGITS);
            
            string result = uppercaseChars + digits;

            return result;
        }
        
        private static string GenerateRandomUppercase(int length)
        {
            Random random = new Random();
            string uppercaseChars = "";
            for (int i = 0; i < length; i++)
            {
                char randomChar = (char)random.Next('A', 'Z' + 1);
                uppercaseChars += randomChar;
            }
            return uppercaseChars;
        }
        
        private static string GenerateRandomDigits(int length)
        {
            Random random = new Random();
            string digits = "";
            for (int i = 0; i < length; i++)
            {
                char randomDigit = (char)random.Next('0', '9' + 1);
                digits += randomDigit;
            }
            return digits;
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
            string newPossibleInvoiceId = "";
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

        public bool markAsPaid(string invoiceId, Invoice.Invoice.Status newStatus)
        {
            for (int i = 0; i < InvoiceStore.invoiceList.Count(); i++)
            {
                if (InvoiceStore.invoiceList[i].invoiceId == invoiceId)
                {
                    InvoiceStore.invoiceList[i].status = newStatus;
                    return false;
                }
            }
            
            return true;
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

            return invoices;
        }

        public List<Invoice.Invoice> GetInvoicesByStatus(string ownerId, Invoice.Invoice.Status status)
        {
            List<Invoice.Invoice> invoices = new List<Invoice.Invoice>();
            for (int i = 0; i < InvoiceStore.invoiceList.Count(); i++)
            {
                if (InvoiceStore.invoiceList[i].ownerId == ownerId && InvoiceStore.invoiceList[i].status == status)
                {
                    invoices.Add(InvoiceStore.invoiceList[i]);
                }
            }
            
            return invoices;
        }
    }
}
