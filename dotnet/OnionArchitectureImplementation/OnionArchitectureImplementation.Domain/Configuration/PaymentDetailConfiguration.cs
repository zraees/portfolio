using OnionArchitectureImplementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureImplementation.Domain.Configuration
{
    public class PaymentDetailConfiguration : EntityTypeConfiguration<PaymentDetail>
    {
        public PaymentDetailConfiguration()
        {
            Property(x => x.CardOwnerName)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.CardNumber)
                .IsRequired()
                .HasMaxLength (16);

            Property(x => x.ExpirationDate)
                .IsRequired()
                .HasMaxLength(5);

            Property(x => x.SecurityCode)
                .IsRequired()
                .HasMaxLength(3);
        }
    }
}
