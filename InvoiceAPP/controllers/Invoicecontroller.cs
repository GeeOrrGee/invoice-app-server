using InvoiceAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using InvoiceAPP.Models.Invoice;

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
        
        //[Route("api/InvoiceAPI/getInvociesByOwner/{ownerId}")]
        [HttpGet("get-invoices-by-onwerId/{ownerId:maxlength(6)}", Name ="GetInvByOwnId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Invoice>> GetInvoicesByOwnerId(string ownerId)
        {
            List<Invoice> ?invoices =  _invoiceService.getInvoicesByOwnerId(ownerId);
            if (invoices != null)
            {
                if (invoices.Any()) return Ok(invoices);
                return NotFound();
            }
            return BadRequest();
        }

        [HttpGet("get-invoice/{invoiceId:length(6)}", Name = "GetInvByInvId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Invoice> GetInvoice(string invoiceId)
        {
            Invoice ?invoice =  _invoiceService.getInvoiceByInvoiceId(invoiceId);
            if (invoice != null)
            {
                if (invoice.status != Invoice.Status.UNINITIALIZED) return Ok(invoice);
                return NotFound();
            }
            return BadRequest();
        }
        
        [HttpGet("get-invoices-by-status/{ownerId:maxlength(6)}/{status:Invoice.Status}", Name = "GetInvByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Invoice>> GetInvoicesByStatus(string ownerId, Invoice.Status status)
        {
            List<Invoice> ?invoices =  _invoiceService.getInvoicesByStatus(ownerId, status);
            if (invoices != null)
            {
                if (invoices.Any()) return Ok(invoices);
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("create-device/")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Invoice> CreateInvoice([FromBody] Invoice invoiceToCreate)
        {
            var invoice =  _invoiceService.newInvoice(invoiceToCreate);
            if (invoice != null)
            {
                if (invoice.status != Invoice.Status.UNINITIALIZED) return NoContent();
                return NotFound();
            }
            return BadRequest();
        }
        
        [HttpDelete("delete/{(invoiceId:length(6)}", Name = "DeleteInvoices")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public ActionResult DeleteInvoice(string invoiceId)
        {
            Invoice invoice = _invoiceService.deleteInvoice(invoiceId);
            if (invoice != null)
            {
                if (invoice.status != Invoice.Status.UNINITIALIZED) return NoContent();
                return NotFound();
            }
            return BadRequest();
        }
        
        [HttpPatch("mark-as-paid/{invoiceId:length(6)}", Name = "MarkAsPaid")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult MarkInvoiceAsPaid(string invoiceId)
        {
            var invoice = _invoiceService.markAsPaid(invoiceId);
            if (invoice != null)
            {
                if (invoice.status != Invoice.Status.UNINITIALIZED) return NoContent();
                return NotFound();
            }
            return BadRequest();
        }
        
        [HttpPatch("edit/{invoiceId:length(6)}", Name = "EditInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult EditInvoice(string invoiceId, JsonPatchDocument<Invoice> invoicePatch)
        {
            Invoice invoiceForApply = new Invoice();
            invoicePatch.ApplyTo(invoiceForApply, ModelState);
            //return statusMappings[_invoiceService.editInvoice(invoiceId, invoice)](null);
            var invoice = _invoiceService.editInvoice(invoiceId, invoiceForApply);
            if (invoice != null)
            {
                if (invoice.status != Invoice.Status.UNINITIALIZED) return NoContent();
                return NotFound();
            }
            return BadRequest();
        }
        
    }
}
