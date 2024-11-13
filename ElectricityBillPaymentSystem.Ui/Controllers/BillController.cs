using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricityBillPaymentSystem.Application.Contracts.Service;
using Microsoft.AspNetCore.Mvc;

namespace ElectricityBillPaymentSystem.Ui.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            this._billService = billService;
        }

        [HttpPost("electricity/verify")]
        public async Task<IActionResult> CreateBill( decimal amount, string phoneNumber)
        {
            var bill = await _billService.CreateBillAsync( amount, phoneNumber);
            return CreatedAtAction(nameof(CreateBill), new { id = bill.Id }, bill);
        }

        [HttpPost("Vend/{billId}/pay")]
        public async Task<IActionResult> ProcessPayment(int billId,int walletId, string phoneNumber)
        {
            await _billService.ProcessPaymentAsync(billId, walletId, phoneNumber);
            return Ok("Payment processed successfully.");
        }

    }
}