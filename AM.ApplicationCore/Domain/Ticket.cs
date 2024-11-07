using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {

        //clé primaire composé entre cle flight et passanger dans la classe TicketConfiguration
        [ForeignKey("MyFlight")]
        public int FlightFK { get; set; }
        [ForeignKey("MyPassenger")]
        public string PassengerFK { get; set; }
        public double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }
        public virtual Flight MyFlight { get; set; }
        public virtual Passenger MyPassenger { get; set; }

    }
}
