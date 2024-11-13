using ElectricityBillPaymentSystem.Application.Contracts.Repository;
using ElectricityBillPaymentSystem.Application.Contracts.Service;
using ElectricityBillPaymentSystem.Application.Dtos;
using ElectricityBillPaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IWalletRepository _walletRepository;
        private readonly ISmsService _smsService;
        private const decimal LowBalanceThreshold = 50.0M;

        public WalletService(IEventPublisher eventPublisher, IWalletRepository walletRepository, ISmsService SmsService)
        {
            this._eventPublisher = eventPublisher;
            this._walletRepository = walletRepository;
            this._smsService = SmsService;
        }

        public async Task<WalletResponseDto> CreateWallet()
        {
            var newWallet = new Wallet()
            {
                Balance = 0,
            };

            await _walletRepository.AddAsync(newWallet);

            var response = new WalletResponseDto()
            {
                Balance = newWallet.Balance
            };
            return response;
        }

        public async Task<string> AddFunds(int walletId, decimal amount)
        {
            var walletExist = await _walletRepository.GetByColumnAsync(x => x.Id == walletId);
            if (walletExist == null)
            {
                return  "Wallet not Found";
            }

            walletExist.Balance += amount;
            await _walletRepository.UpdateASync(walletExist);
            // Check if wallet balance falls below the threshold after adding funds
            if (walletExist.Balance < LowBalanceThreshold)
            {
                await _smsService.SendSmsAsync("phoneNumber", "Warning: Your wallet balance is low.");
            }
            return "Funds Added Successfully";
        }

        
    }
}
