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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //Configurer la relation Many to Many flight&passenger
            //renomer la table d'association
           /* builder.HasMany(f => f.passengers)
                .WithMany(p=>p.flights)
                .UsingEntity(t=>t.ToTable("Reservations"));*/
            //one to many flight &plane
            builder.HasOne(f => f.myPlane)
                .WithMany(p => p.flights)
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            
        }
    }
}
