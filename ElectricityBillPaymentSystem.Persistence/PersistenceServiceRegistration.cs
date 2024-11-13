using ElectricityBillPaymentSystem.Application.Contracts.Repository;
using ElectricityBillPaymentSystem.Persistence.DataBaseContext;
using ElectricityBillPaymentSystem.Persistence.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityBillPaymentSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection RegisterPersistenceService(this IServiceCollection services, IConfiguration conn)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    conn.GetConnectionString("Conn")));
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            return services;

            ;
        }
    }
}
