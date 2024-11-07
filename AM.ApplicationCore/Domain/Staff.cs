using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string function {  get; set; }
        [DataType(DataType.Currency)]
        public double salary { get; set; }
        public DateTime employmentDate { get; set; }

        public override string ToString()
        {
            return base.ToString()+$"employmentDate = {employmentDate} , salary = {salary}, function = {function} ";
        }
        //*******************************
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a staff member");
        }
    }
}
