using ElectricityBillPaymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Domain.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }
        // public int WalletId { get; set; }

        // public Wallet Wallet { get; set; }
    }
}
