using ElectricityBillPaymentSystem.Domain.Entities;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Contracts.Service
{
    public interface IBillService
    {
        Task<Bill> CreateBillAsync(int walletId, decimal amount, string phoneNumber);
        Task<string> ProcessPaymentAsync(int billId, string phoneNumber);
    }
}
