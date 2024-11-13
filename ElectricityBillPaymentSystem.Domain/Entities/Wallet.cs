using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Bill> Bills { get; set; }


        
    }


}
