﻿using ElectricityBillPaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Contracts.Repository
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
    }
}
