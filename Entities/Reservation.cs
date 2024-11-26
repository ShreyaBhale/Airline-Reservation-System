using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation
    {
        public int TicketNo { get; set; }
        public int FlightId { get; set; }
        public DateTime DateOfBooking { get; set; }
        public DateTime JourneyDate { get; set; }
        public string PassengerName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int NoOfTickets { get; set; }
        public double TotalFare { get; set; }
        public string Status { get; set; }

        public List<Passenger> Passengers { get; set; } = new List<Passenger>();

        public class Passenger
        {
            public string Name { get; set; }
        }


        public Reservation(int TicketNo, int FlightId, DateTime DateOfBooking, DateTime JourneyDate, string PassengerName, string ContactNo, string Email, int NoOfTickets, double TotalFare, string Status)
        {
            this.TicketNo = TicketNo;
            this.FlightId = FlightId;
            this.DateOfBooking = DateOfBooking;
            this.JourneyDate = JourneyDate;
            this.PassengerName = PassengerName;
            this.ContactNo = ContactNo;
            this.Email = Email;
            this.NoOfTickets = NoOfTickets;
            this.TotalFare = TotalFare;
            this.Status = Status;
        }

        public Reservation() { }
    }
}
