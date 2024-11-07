using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string healthInformation {  get; set; }
        public string nationality { get; set; }



        public override string ToString()
        {
            return base.ToString()+$" healthInformation = {healthInformation} , nationality = {nationality}";
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a traveller");
        }

    }
}   
