using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DeletePlane()
        {
            DateTime actualDate = DateTime.Now;
            foreach(Plane p in GetMany(p=>DateTime.Now.Year - p.ManufactureDate.Year >10 ))
            {
                Delete(p);
                Commit();
            }
            
        }

        public IList<IGrouping<DateTime ,Flight>> GetFlight(int n)
        {
            return GetAll().OrderByDescending(p=>p.PlaneId)
                .Take(n)
                .SelectMany(p=>p.flights)
                .GroupBy(f=>f.flighDtae)
                .ToList();
        }

        public IList<Traveller> GetTravellers(Plane p)
        {
            return unitOfWork.Repository<Plane>().GetById(p.PlaneId).flights
                .SelectMany(f=>f.Tickets)
                .Select(t=>t.MyPassenger).OfType<Traveller>().Distinct().ToList();
        }
        
    }
}
