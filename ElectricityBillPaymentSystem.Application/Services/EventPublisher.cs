using ElectricityBillPaymentSystem.Application.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Services
{
    public class EventPublisher : IEventPublisher
    {
        public async Task PublishAsync(string eventName, object data)
        {
            // Log the event instead of actually publishing it
            Console.WriteLine($"Event Published: {eventName}, Data: {data}");
            await Task.CompletedTask;
        }
    }
}
