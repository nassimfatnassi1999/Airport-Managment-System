using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime birthDate { get; set; }
        [Key]
        [StringLength(7)] //maximum 7 caracteres
        public string passportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }
        public FullName FullName { get; set; } //type d'entité détenus
        //[DataType(DataType.PhoneNumber]
        [RegularExpression("^[0 - 9]{8}$")]
        public string phoneNumber { get; set; }

        //public ICollection<Flight> flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }



        public override string ToString()
        {
            return $"firstName = {FullName.firstName} , lastName = {FullName.lastName}";
        }

        //********************************
        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return this.firstName.Equals(firstName) && this.lastName.Equals(lastName);
        //}
        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return firstName == firstName && lastName == lastName && emailAddress == email;
        //}
        // soit oasser 2 param soit 3 param
        public bool CheckProfile23(string firstName, string lastName, string? email = null)
        {
            if (email != null)
                return this.FullName.firstName == FullName.firstName && this.FullName.lastName == FullName.lastName && this.emailAddress == email;
            else
                return this.FullName.firstName == FullName.firstName && this.FullName.lastName == FullName.lastName;
        }
        //**********************************
        public virtual void PassengerType()
        {
            Console.Write("I am a Passenger ");
        }

    }
}
