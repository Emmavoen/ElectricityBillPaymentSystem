using ElectricityBillPaymentSystem.Application.Contracts.Repository;
using ElectricityBillPaymentSystem.Application.Contracts.Service;
using ElectricityBillPaymentSystem.Domain.Entities;
using ElectricityBillPaymentSystem.Domain.Enums;
using System;
using System.Threading.Tasks;


namespace ElectricityBillPaymentSystem.Application.Services
{
    public class BillService : IBillService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IBillRepository _billRepository;
        private readonly ISmsService _smsService;
        private readonly IWalletRepository _walletRepository;
        

        public BillService(IEventPublisher eventPublisher, IBillRepository billRepository, ISmsService SmsService, IWalletRepository walletRepository)
        {
            this._billRepository = billRepository;
            this._eventPublisher = eventPublisher;
            this._smsService = SmsService;
            this._walletRepository = walletRepository;
        }


        public async Task<Bill> CreateBillAsync( decimal amount, string phoneNumber)
        {
            var bill = new Bill
            {
                
                Amount = amount,
                Status = Status.Pending,
                
            };
            await _billRepository.AddAsync(bill);
            // Send SMS Notification
            await _smsService.SendSmsAsync(phoneNumber, $"A new bill of {amount} has been created with status: {bill.Status}.");

            // Publish Event
            await _eventPublisher.PublishAsync("bill_created", new { BillId = bill.Id, Amount = amount });


            return bill;
        }

        public async Task<string> ProcessPaymentAsync(int billId, int walletId, string phoneNumber)
        {

            var bill = await _billRepository.GetByColumnAsync(x => x.Id == billId);
            if (bill == null)
            { 
                    return "Bill not Found";
            };
            if(bill.Status == Status.Paid)
            {
                return "Bill is already paid";
            }

            var wallet = await _walletRepository.GetByColumnAsync(x => x.Id == walletId);
            if(wallet == null)
            {
                return "Wallet not found";
            }
            if (wallet.Balance < bill.Amount)
            {
                return "Insufficient wallet balance";
            }

            wallet.Balance -= bill.Amount;
            bill.Status = Status.Paid;

            await _walletRepository.UpdateASync(wallet);
            await _billRepository.UpdateASync(bill);

            // Send SMS Notification
            await _smsService.SendSmsAsync(phoneNumber, $"Your payment of {bill.Amount} was successful. Bill status: Paid.");

            // Publish Event
            await _eventPublisher.PublishAsync("payment_completed", new { BillId = bill.Id, Amount = bill.Amount });

            return "Payment Successfull";
        }

    }
}
