using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Contracts.Service
{
    public interface IEventPublisher
    {
        Task PublishAsync(string eventName, object data);
    }
}
