using ElectricityBillPaymentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricityBillPaymentSystem.Persistence.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(b => b.Status).IsRequired().HasMaxLength(20);

        
        }

        
    }
}
