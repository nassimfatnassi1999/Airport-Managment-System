using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        //propriétes
        public string Pilot { get; set; }
        public string destination {  get; set; }
        public string departure { get; set; }
        public DateTime flighDtae { get; set; }
        [Key]
        public int flightId { get; set; }
        public DateTime effectiveArrival { get; set;}
        public double estimateDuration { get; set;}
        //la relation (la propriétes de navigation)
        [ForeignKey("myPlane")]
        public int PlaneId { get; set; }
        public virtual Plane myPlane { get; set; }
        // public ICollection<Passenger> passengers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public string Airline { get; set; }

        public override string ToString()
        {
         
            string x = $"flightID = {flightId}, Destination = {destination}, Date = {flighDtae}, estimateDuration = {estimateDuration}\n";

            return x;
        }
    }



    }

