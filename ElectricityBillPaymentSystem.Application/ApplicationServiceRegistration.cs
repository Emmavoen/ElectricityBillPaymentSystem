using ElectricityBillPaymentSystem.Application.Contracts.Repository;
using ElectricityBillPaymentSystem.Application.Contracts.Service;
using ElectricityBillPaymentSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityBillPaymentSystem.Application
{
    public static  class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
        {

            
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IEventPublisher, EventPublisher>();
            return services;

            ;
        }
    }
}
