using InvoiceAPP.Models.DTO;

namespace InvoiceAPP.Data
{
    public static class InvoiceStore
    {
        public static  List<InvoiceDTO> invoiceList = new List<InvoiceDTO>
        {
                new InvoiceDTO{InvoiceId = 1, Amount = 1000.0, FromUserID = 1, ToUserID = 3},
                new InvoiceDTO{InvoiceId = 2, Amount = 1500.0, FromUserID = 2,ToUserID  = 3}
        };
    }
}

