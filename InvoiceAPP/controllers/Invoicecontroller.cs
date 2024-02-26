using InvoiceAPP.Models;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using InvoiceAPP.Models.Invoice;
using InvoiceAPP.Models.Services;

namespace InvoiceAPP.Controllers
{
    [Route("api/InvoiceAPI")]
    [ApiController]
    public class Invoicecontroller : ControllerBase
    {
        private readonly IService _service;

        public Invoicecontroller(IService? invoiceService)
        {
            _service = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
        }
        
        //[Route("api/InvoiceAPI/getInvociesByOwner/{ownerId}")]


        [HttpGet("get-invoice/{invoiceId:length(6)}", Name = "GetInvByInvId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InvoiceDTO> GetInvoice(string invoiceId)
        {
            InvoiceDTO ?invoice =  _service.GetinvoiceID(invoiceId);
            if (invoice != null)
            {
                 return Ok(invoice);
            }
            return NotFound();;
        }
        
        [HttpGet("get-invoices-by-status/{ownerId:maxlength(6)}/{status:Invoice.Status}", Name = "GetInvByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Invoice>> GetInvoicesByStatus(string status)
        {
            List<InvoiceDTO> ?invoices =  _service.GetinvoiceListByStatus(status).ToList();
            if (invoices != null)
            {
                if (invoices.Any()) return Ok(invoices);
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("create-panding/")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<InvoiceDTO> CreatePanding([FromBody] InvoiceDTO invoiceToCreate)
        {
            var invoice =  _service.CreatePending(invoiceToCreate);
            if (invoice != null)
            {
                return NoContent();
            }
            return NotFound();
        }
        
        [HttpPost("create-draft/")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<InvoiceDTO> CreateDraft([FromBody] InvoiceDTO invoiceToCreate)
        {
            var invoice =  _service.CreateDraft(invoiceToCreate);
            if (invoice != null)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("delete/{(invoiceId:length(6)}", Name = "DeleteInvoices")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult DeleteInvoice(string invoiceId)
        {
            _service.DeleteInvoice(invoiceId);
            return NoContent();
        }
        
        [HttpPatch("mark-as-paid/{invoiceId:length(6)}", Name = "MarkAsPaid")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult MarkInvoiceAsPaid(string invoiceId)
        {
            var invoice = _service.MarkAsPaid(invoiceId);
            if (invoice != null)
            {
                return NoContent();
            }
            return NotFound();
        }
        
        [HttpPatch("edit/{invoiceId:length(6)}", Name = "EditInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult EditInvoice(string invoiceId, JsonPatchDocument<InvoiceDTO> invoicePatch)
        {
            InvoiceDTO invoiceForApply = new InvoiceDTO();
            invoicePatch.ApplyTo(invoiceForApply, ModelState);
            _service.UpdateInvoice(invoiceForApply);
            return NoContent();
        }
        
    }
}
