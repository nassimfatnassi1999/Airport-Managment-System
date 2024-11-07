using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        bool AvailablePlane(int n, Flight f);
        IList<Staff> GetStaff(int id);
        IList<Passenger> GetPassengerOnPlane(Plane p , DateTime d);

        void DisplayNumberPassenger(DateTime d1 , DateTime d2);
        public IEnumerable<Flight> SortFlights();
    }
}
