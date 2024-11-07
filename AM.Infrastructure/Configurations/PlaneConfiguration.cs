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
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            //primarykey planeID ====[key]
            builder.HasKey(p => p.PlaneId);
            //nom de la table doit etre "MyPlanes"
            builder.ToTable("MyPlanes");
            //modifier nom de column
            builder.Property(p => p.capacity).HasColumnName("PlaneCapacity");
            
        }
    }
}
