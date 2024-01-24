using InvoiceAPP.Data;
using InvoiceAPP.Models;
using InvoiceAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceAPP.Models.Invoice;
using InvoiceAPP.Controllers;

namespace InvoiceAPP.Controllers
{
    [Route("api/InvoiceAPI")]
    [ApiController]
    public class Invoicecontroller : ControllerBase
    {
        private IInvoiceService _invoiceService;

        private Dictionary<STATUS_CODE, Func<object, ActionResult>> statusMappings;

        public Invoicecontroller(IInvoiceService invoiceService)
        {
            statusMappings = new Dictionary<STATUS_CODE, Func<object, ActionResult>>
            {
                { STATUS_CODE.OK, content => Ok(content) },
                { STATUS_CODE.BAD_REQUEST, content => BadRequest(content) },
                { STATUS_CODE.NOT_FOUND, content => NotFound(content) },
                { STATUS_CODE.NO_CONTENT, _ => NoContent() },
            };
            _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
        }
        
        //[Route("api/InvoiceAPI/getInvociesByOwner/{ownerId}")]
        [HttpGet("get-invoices-by-onwerId/{ownerId:maxlength(6)}", Name ="GetInvByOwnId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Invoice>> GetInvoicesByOwnerId(string ownerId)
        {
            var invoices =  _invoiceService.getInvoicesByOwnerId(ownerId);
            Func<object, ActionResult> func = statusMappings[invoices.Key];
            return func(invoices.Value);
        }

        [HttpGet("get-invoice/{invoiceId:length(6)}", Name = "GetInvByInvId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Invoice> GetInvoice(string invoiceId)
        {
            var invoices =  _invoiceService.getInvoiceByInvoiceId(invoiceId);
            Func<object, ActionResult> func = statusMappings[invoices.Key];
            return func(invoices.Value);
        }
        
        [HttpGet("get-invoices-by-status/{ownerId:maxlength(6)}/{status:Invoice.Status}", Name = "GetInvByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Invoice>> GetInvoicesByStatus(string ownerId, Invoice.Status status)
        {
            var invoices =  _invoiceService.getInvoicesByStatus(ownerId, status);
            Func<object, ActionResult> func = statusMappings[invoices.Key];
            return func(invoices.Value);
        }

        [HttpPost("create-device/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<InvoiceDTO> CreateInvoice([FromBody] Invoice invoice)
        {
            var invoices =  _invoiceService.newInvoice(invoice);
            Func<object, ActionResult> func = statusMappings[invoices.Key];
            return func(invoices.Value);
        }
        
        [HttpDelete("delete/{(invoiceId:length(6)}", Name = "DeleteInvoices")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public ActionResult DeleteInvoice(string invoiceId)
        {
            return statusMappings[_invoiceService.deleteInvoice(invoiceId)](null);
        }

        
        [HttpPatch("mark-as-paid/{invoiceId:length(6)}", Name = "MarkAsPaid")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult MarkInvoiceAsPaid(string invoiceId)
        {
            return statusMappings[_invoiceService.markAsPaid(invoiceId)](null);
        }


        
        [HttpPatch("edit/{invoiceId:length(6)}", Name = "EditInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult EditInvoice(string invoiceId, JsonPatchDocument<Invoice> invoicePatch)
        {
            Invoice invoice = new Invoice();
            invoicePatch.ApplyTo(invoice, ModelState);
            return statusMappings[_invoiceService.editInvoice(invoiceId, invoice)](null);
        }
        
    }
}
