using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        IUnitOfWork UnitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public bool AvailablePlane(int n, Flight f)
        {
            int capacity = f.myPlane.capacity;
            int nbrTicket = f.Tickets.Count();

            return capacity > nbrTicket + n;
        }

        public void DisplayNumberPassenger(DateTime d1, DateTime d2)
        {
            int nbr = 0;
            var querry = GetMany(f => f.flighDtae > d1 && f.flighDtae < d2)
                .SelectMany(f => f.Tickets)
                .GroupBy(t => t.MyFlight.flighDtae)
                .Select(x => new { date = x.Key, nbr = x.Count() });

            foreach(var item in querry)
            {
                Console.WriteLine("Date de vol = " + item.date + " nbr de voyageurs = " + item.nbr);
            }
           
        }

        public IList<Passenger> GetPassengerOnPlane(Plane p, DateTime d)
        {
            return Get(f=>f.myPlane==p && f.flighDtae==d)
                .Tickets
                .Select(t=>t.MyPassenger)
                .ToList();
        }

        public IList<Staff> GetStaff(int id)
        {
            return GetById(id).Tickets
                .Select(t=>t.MyPassenger)
                .OfType<Staff>().ToList();
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.flighDtae);
        }
    }
}
