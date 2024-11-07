using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum planeType { Boing, Airbus}
    public class Plane 
    {
        //propriétes
        [Range(0, int.MaxValue)]
        public int capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public planeType planeType { get; set; }
        //la relation "liste de flight" (la propriétes de navigation)
          public virtual ICollection<Flight> flights { get; set; }

        public Plane(planeType pt, int capacity, DateTime date)
        {
            planeType = pt;
            capacity = capacity;
            ManufactureDate = date;
        }
        public Plane() { }
        public override string ToString()
        {
            string x = $"Capacity = {capacity}, Date = {ManufactureDate}, PlaneId = {PlaneId}, planeType = {planeType}\nFlights:\n";

           /* foreach (Flight flight in flights)
            {
                x += flight.ToString(); 
                x += "\n"; 
            }*/

            return x;
        }

    }
}
