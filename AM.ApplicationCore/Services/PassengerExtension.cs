using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        //methode d'extention contient le mot this
        public static void UpperFullName(this Passenger p)
        {
           p.FullName.firstName = p.FullName.firstName[0].ToString().ToUpper()+p.FullName.firstName.Substring(1);
           p.FullName.lastName =  p.FullName.lastName[0].ToString().ToUpper() + p.FullName.lastName.Substring(1);
        }
    }
}
