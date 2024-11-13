using ElectricityBillPaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Dtos
{
    public class WalletResponseDto
    {
        public decimal Balance { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}
