using ElectricityBillPaymentSystem.Application.Contracts.Repository;
using ElectricityBillPaymentSystem.Domain.Entities;
using ElectricityBillPaymentSystem.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Persistence.RepositoryImplementation
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
