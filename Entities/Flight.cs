using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class Flight
    {
        public int FlightID { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int NoOfSeats { get; set; }
        public double Fare { get; set; }

        public Flight(int flightNumber, DateTime LaunchDate, DateTime DepartureTime, DateTime ArrivalTime, string origin, string destination, int noOfSeats, decimal fare)
        {
            this.FlightID = flightNumber;
            this.LaunchDate = LaunchDate;
            this.DepartureTime = DepartureTime;
            this.ArrivalTime = ArrivalTime;
            this.Origin = origin;
            this.Destination = destination;
            this.NoOfSeats = noOfSeats;
            this.Fare = Fare;
        }

        public Flight() { }
    }
}
