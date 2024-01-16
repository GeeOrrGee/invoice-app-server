using InvoiceAPP.Data;
using InvoiceAPP.Models;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
namespace InvoiceAPP.Controllers
{
    [Route("api/InvoiceAPI")]
    [ApiController]
    public class InvoiceAPIcontroller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<InvoiceDTO> GetInvoices()
        {
            return InvoiceStore.invoiceList;
        }

        [HttpGet("id")]
        public InvoiceDTO GetInvoices(int id)
        {
            return InvoiceStore.invoiceList.FirstOrDefault(u => u.Id==id);
        }
    }
}
