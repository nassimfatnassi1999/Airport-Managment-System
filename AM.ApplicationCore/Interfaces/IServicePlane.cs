﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        IList<Traveller> GetTravellers(Plane p);
        IList<IGrouping<DateTime, Flight>> GetFlight(int n);
        void DeletePlane();
       
    }
}
