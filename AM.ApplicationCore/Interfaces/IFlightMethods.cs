using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
       public List<DateTime> GetFlightDates(string destination);
      
       public void  GetFlights(string filterType, string filterValue);
        public IEnumerable<DateTime> GetFlightDatesLINQ(string destination); //reformuler la methode en langage LINQ
        //les methodes par le langage LINQ
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        //IEnumerable<Passenger> SeniorTravellers(Flight flight);
        void DestinationGroupedFlights();



    }
}
