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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<InvoiceDTO>> GetInvoices()
        {
            return Ok(InvoiceStore.invoiceList);
        }

        [HttpGet("id:int", Name = "GetInvoices")]
       [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InvoiceDTO> GetInvoices(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var invoice = InvoiceStore.invoiceList.FirstOrDefault(u => u.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<InvoiceDTO> CreateInvoice([FromBody] InvoiceDTO invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (invoice == null)
            {
                return BadRequest(invoice);
            }
            if(invoice.Id != 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            invoice.Id = InvoiceStore.invoiceList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            InvoiceStore.invoiceList.Add(invoice);

            return CreatedAtRoute("GetInvoices", new { id=invoice.Id}, invoice );
        }

        [HttpDelete("id:int", Name = "DeleteInvoices")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteInvoice(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var invoice = InvoiceStore.invoiceList.FirstOrDefault(u => u.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }
            InvoiceStore.invoiceList.Remove(invoice);

            return NoContent();
        }

    }
}
