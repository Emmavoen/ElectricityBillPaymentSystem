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
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            this._walletService = walletService;
        }
        [HttpPost("{walletId}/add-funds")]
        public async Task<IActionResult> AddFunds(int walletId, decimal amount, string phoneNumber)
        {
           var result =  await _walletService.AddFunds(walletId, amount, phoneNumber);
            return Ok(result);
        }
    }
}