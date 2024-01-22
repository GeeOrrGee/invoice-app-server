using InvoiceAPP.Data;
using InvoiceAPP.Models;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceAPP.Controllers
{
    [Route("api/InvoiceAPI")]
    [ApiController]
    public class Invoicecontroller : ControllerBase
    {
        private IInvoiceService _invoiceService;

        public Invoicecontroller(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
            
        }


        [HttpGet("userID:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<InvoiceDTO>> GetInvoices(int userID)
        {
            var invoices =  _invoiceService.GetInvoiceList(userID);
            return Ok(invoices);
        }

        [HttpGet("id:int", Name = "GetInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InvoiceDTO> GetInvoice(int id)
        {
            var invoice =  _invoiceService.GetInvoice(id);
            return Ok(invoice);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<InvoiceDTO> CreateInvoice([FromBody] InvoiceDTO invoice)
        {
            _invoiceService.CreateInvoice(invoice);
            return CreatedAtRoute("GetInvoices", new { invloiceId = invoice.InvoiceId }, invoice);
        }

        [HttpDelete("id:int", Name = "DeleteInvoices")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteInvoice(int id)
        {
            _invoiceService.DeleteInvoice(id);
            return NoContent();
        }

    }
}
