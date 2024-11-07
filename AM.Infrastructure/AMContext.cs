using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public  class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //UseLazyLoadingProxies() pour activer la chargement de donnees entre deux tables 
            //add virtual dans tous les propriétes de navigation.
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=NassimFatnassiDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        //les images de table
        public DbSet<Passenger> Passangers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        /// <summary>
        /// lordre de priorité des outils de  conventions :
        /// Pré-convention < Annotations < Configuration_Fluent_Api
        /// </summary>
        
        //Appel a la classe de conf dans dossier Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new  FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
        }
        //redef la pre-conv ensemble de propriétés
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //changer tous les column de type DateTime2 to date
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            //changer tous les types string de longuer 50
            //configurationBuilder.Properties<string>().HaveMaxLength(50);
        }


    }
    
}
