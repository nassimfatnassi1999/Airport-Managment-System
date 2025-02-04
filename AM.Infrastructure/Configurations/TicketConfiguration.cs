﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class TicketConfiguration :IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder) {

            //definir la clé primaire de la classe ticket
            builder.HasKey(t => new { t.PassengerFK, t.FlightFK });
            //les cle etranger
            builder.HasOne(t => t.MyPassenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PassengerFK);
            builder.HasOne(t => t.MyFlight)
               .WithMany(f => f.Tickets)
               .HasForeignKey(t => t.FlightFK);

        }
    }
}
