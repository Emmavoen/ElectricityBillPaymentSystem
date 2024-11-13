using ElectricityBillPaymentSystem.Application.Dtos;
using ElectricityBillPaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Contracts.Service
{
    public interface IWalletService
    {
        Task<WalletResponseDto> CreateWallet();
        Task<string> AddFunds(int walletId, decimal amount);
    }
}
