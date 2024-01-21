using InvoiceAPP.Data;
using InvoiceAPP.Models;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPP.Controllers
{
    [Route("api/InvoiceAPI")]
    [ApiController]
    public class Invoicecontroller : Controller
    {
        private InvoiceService _invoiceservice;

        public Invoicecontroller(InvoiceService invoiceService)
        {
            _invoiceservice = invoiceService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoices()
        {
            var invoices = await _invoiceservice.ListInvoices();
            return Ok(invoices);
        }

        [HttpGet("id:int", Name = "GetInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(int id)
        {
            var invoice = await _invoiceservice.GetInvoice(id);
            return Ok(invoice);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<InvoiceDTO> CreateInvoice([FromBody] InvoiceDTO invoice)
        {
            _invoiceservice.CreateInvoice(invoice);
            return CreatedAtRoute("GetInvoices", new { id = invoice.Id }, invoice);
        }

        [HttpDelete("id:int", Name = "DeleteInvoices")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteInvoice(int id)
        {
            _invoiceservice.DeleteInvoice(id);
            return NoContent();
        }

    }
}
