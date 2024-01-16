using InvoiceAPP.Models.DTO;

namespace InvoiceAPP.Data
{
    public static class InvoiceStore
    {
        public static List<InvoiceDTO> invoiceList = new List<InvoiceDTO>
        {
                new InvoiceDTO{Id=1, Amount=1000, PayTo="Facina" },
                new InvoiceDTO{Id=2, Amount=1500, PayTo="Guga"}
        };
    }
}

