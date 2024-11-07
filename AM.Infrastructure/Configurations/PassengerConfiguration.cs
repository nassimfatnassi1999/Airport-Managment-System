using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            //OwnsOne(p=>p.FullName) equivalent d [owned]
            builder.OwnsOne(p => p.FullName, full =>
            {
                full.Property(n => n.firstName).HasColumnName("PassFirstName");
                full.Property(n => n.lastName).HasColumnName("PassLastName").IsRequired();
                
            });
            //modifier le nom de column descriminator
            //builder.HasDiscriminator<string>("IsTraveller")
            //    .HasValue<Traveller>("1")
            //    .HasValue<Staff>("2")
            //    .HasValue<Passenger>("0");
        }
    }
}
