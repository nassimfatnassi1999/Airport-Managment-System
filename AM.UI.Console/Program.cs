// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

//Console.WriteLine("Hello, Nassim!");
////instance objet plane
//Plane p1 = new Plane{ }; 
//p1.capacity = 255;
//p1.ManufactureDate = new DateTime(2024,02,29);
//p1.planeType = planeType.Boing;
//p1.PlaneId = 10;
////**********instancier plane*****************
//Plane p2 = new Plane{ capacity = 25 , ManufactureDate = DateTime.Now, PlaneId= 14 , planeType= planeType.Airbus};

//Plane p3 = new Plane(planeType.Boing, 300, DateTime.Now);

////*******************************
//Console.WriteLine(p1.ToString());
//Console.WriteLine(p2.ToString());

////***************instancier passenger*******************
/*Passenger pas1 = new Passenger()
{
    FullName.firstName = "nassim",
    FullName.lastName = "fatnassihnifi",
    emailAddress = "fatnassihnifi.nassim@esprit.tn",
    birthDate = DateTime.Now,
};*/

//Console.WriteLine(pas1.ToString()); 
////tester la methode  ploymorphism par signature de methode
//Console.WriteLine(pas1.CheckProfile23("alulou","charouf"));
//Console.WriteLine(pas1.CheckProfile23("nassim", "fatnassihnifi", "fatnassihnifi.nassim@esprit.tn"));
////*************************************
//Staff staff= new Staff { };
//staff.PassengerType();
//Traveller traveller=new Traveller { };
//traveller.PassengerType();
//****************************************************
FlightMethods fm = new FlightMethods { Flights = TestData.listFlights};
//*******************************************
Console.WriteLine("la methode GetFlightDATE");
foreach (var item in fm.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
//***********************************
Console.WriteLine("la methode GetFlight avec filter");
fm.GetFlights("EstimatedDuration", "105");
//************************************
Console.WriteLine("la methode ShowFlightDetails avec LINQ");
fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("la methode ShowFlightDetails avec Delegue");
fm.FlightDetailsDel(TestData.BoingPlane);

//***********************************
Console.WriteLine("la methode ProgrammedFlightNumber avec LINQ");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 02, 01, 21, 10, 10)));
//***********************************
Console.WriteLine("la methode DurationAverage avec LINQ");
Console.WriteLine(fm.DurationAverage("Paris"));
////***********************************
Console.WriteLine("la methode OrderedDurationFlights avec LINQ");
foreach(var item in fm.OrderedDurationFlights())
{
    Console.WriteLine(item);
}
////***********************************
Console.WriteLine("la methode SeniorTravellers avec LINQ");
/*foreach(var item in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}*/
////***********************************
Console.WriteLine("la methode DestinationGroupedFlights avec LINQ");
fm.DestinationGroupedFlights();
//**************************************
/*Console.WriteLine("la methode to upper extension");
pas1.UpperFullName();
Console.WriteLine(pas1.FullName.firstName + " " +  pas1.FullName.lastName);*/
//******************************
AMContext context = new AMContext();
/*context.Planes.Add(TestData.BoingPlane);
context.Flights.Add(TestData.flight3);
context.SaveChanges();
Console.WriteLine("ADD dans la base suucessfully!!!");*/
Console.WriteLine(context.Flights.First().myPlane.capacity); //telecharger proxies and add uselazylodprox on AMCONTEXT