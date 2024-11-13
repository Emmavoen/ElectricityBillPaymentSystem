using ElectricityBillPaymentSystem.Application.Contracts.Service;
using System.Threading.Tasks;
using System;

namespace ElectricityBillPaymentSystem.Application.Services
{
    public class SmsService : ISmsService
    {
        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            Console.WriteLine($"SMS sent to {phoneNumber}: {message}");
            await Task.CompletedTask;
        }
    }
}
