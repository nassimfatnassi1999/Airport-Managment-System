using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight> { };
        //*******************les delegues********************************************
        public Action<Plane> FlightDetailsDel;
        public Func<String, double> DurationAverageDel;

        public FlightMethods() {
            // FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
            {
                var query = from f in Flights
                            where f.myPlane == p
                            select new { f.destination, f.flighDtae };
                foreach (var f in query)
                {
                    Console.WriteLine("FlightDestination = " + f.destination + " " + "FlightDate = " + f.flighDtae);
                }
            };
            //DurationAverageDel = DurationAverage;
            DurationAverageDel = d =>
            {
                var querry = from f in Flights
                             where f.destination == d
                             select f.estimateDuration;
                return querry.Average();
            };
        }

        public void DestinationGroupedFlights()
        {
            //var query = from f in Flights
            //            group f by f.destination;
            var query = Flights.GroupBy(f => f.destination);

            foreach (var group in query)
            {
                Console.WriteLine($"Destination: {group.Key}");

                foreach (var flight in group)
                {

                    Console.WriteLine($"Décollage : {flight.flighDtae}");
                }
            }

        }

        public double DurationAverage(string destination)
        {
            //var querry = from f in Flights
            //             where f.destination == destination
            //             select f.estimateDuration;
            //return querry.Average();
            return Flights.Where(f=>f.destination==destination).Select(f=>f.estimateDuration).Average();    
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>(); //liste vide
            //for(int i = 0; i < Flights.Count; i++)
            //{
            //    if(Flights[i].destination == destination)
            //    {
            //        result.Add(Flights[i].flighDtae);
            //    }
            //}
            foreach (Flight f in Flights)
            {
                if (f.destination == destination)
                {
                    result.Add(f.flighDtae);
                }
            }
            return result;
        }

        public IEnumerable<DateTime> GetFlightDatesLINQ(string destination)
        {
            //IEnumerable<DateTime> query = from f in Flights
            //                              where f.destination == destination
            //                              select f.flighDtae;
            //return query;
            return Flights.Where(f=> f.destination == destination).Select(f=>f.flighDtae);
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "destination":
                    foreach (Flight f in Flights)
                    {
                        if (filterValue == f.destination)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "departure ":
                    foreach (Flight f in Flights)
                    {
                        if (filterValue == f.departure)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (DateTime.Parse(filterValue) == f.flighDtae)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                    {
                        if (double.Parse(filterValue) == f.estimateDuration)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;

                default: Console.WriteLine("pas de vols"); break;
            }
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.estimateDuration descending
            //            select f;
            //return query;
            return Flights.OrderByDescending(f => f.estimateDuration);

           
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {

            //var querry = from f in Flights
            //             where f.flighDtae >= startDate
            //             && f.flighDtae < startDate.AddDays(7)
            //             select f;

            //return querry.Count();
            return Flights
                      .Count(f => f.flighDtae >= startDate && f.flighDtae < startDate.AddDays(7));
        }

       /* public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            //var querry = from p in flight.passengers.OfType<Traveller>()
            //             orderby p.birthDate ascending
            //             select p;
            //return querry.Take(3);
            return flight.passengers
                            .OfType<Traveller>()
                            .OrderBy(p => p.birthDate)
                            .Take(3);

        }*/

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.myPlane == plane
            //            select new { f.destination, f.flighDtae };
            //foreach (var f in query)
            //{
            //    Console.WriteLine("FlightDestination = " + f.destination + " " + "FlightDate = " + f.flighDtae);
            //}
            var lambda = Flights.Where(f => f.myPlane == plane).Select(f => new { f.destination, f.flighDtae });
            foreach (var f in lambda)
            {
                Console.WriteLine("FlightDestination = " + f.destination + " " + "FlightDate = " + f.flighDtae);
            }
        }
        //******************************************************************************************


    }
}
