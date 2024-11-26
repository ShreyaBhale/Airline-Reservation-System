using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Common;
using System.Security.AccessControl;
using AirlineReservation.Exceptions;

namespace AirlineReservation.DataAccessLayer
{
    public class ReservationDAL
    {
        public static List<Reservation> reservationList = new List<Reservation>();

        static void Main()
        {
            // Create a list of passengers
            var passengers = new List<Reservation.Passenger>
            {
                new Reservation.Passenger { Name = "Devyani Harpale" },
                new Reservation.Passenger { Name = "Shreya Bhale" },
                new Reservation.Passenger { Name = "Tarun Pakhare"},
                new Reservation.Passenger { Name = "Parth" },
                new Reservation.Passenger { Name = "Pranay" },
            };

            // Create a Reservation instance with hardcoded values
            Reservation reservation = new Reservation(
                TicketNo: 12345,
                FlightId: 67890,
                DateOfBooking: DateTime.Now,
                JourneyDate: new DateTime(2024, 8, 15),
                PassengerName: "Shreya",
                ContactNo: "9988776655",
                Email: "devyaniharpale@gmail.com",
                NoOfTickets: 2,
                TotalFare: 60000,
                Status: "Booked"
            );

        }

        public bool BookTicket(Reservation booking)
        {

            bool booked = false;
            try
            {
                booked = true;
                booking.Status = "Booked";
                booking.TotalFare = PaymentDAL.CalculateTotalFare(booking.FlightId, booking.NoOfTickets);
                booking.DateOfBooking = DateTime.Now;
                reservationList.Add(booking);
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return booked;
        }

        public Reservation SearchTicketDAL(int Ticketno)
        {
            Reservation searchTicket = null;
            try
            {
                searchTicket = reservationList.Find(f => f.TicketNo == Ticketno);
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return searchTicket;
        }
        
        public bool UpdateBookingDAL(Reservation updateTicket)
        {
            bool BookingUpdated = false;
            try
            {
                Reservation reserve = SearchTicketDAL(updateTicket.TicketNo);
                reserve.DateOfBooking = updateTicket.DateOfBooking;
                reserve.JourneyDate = updateTicket.JourneyDate;
                reserve.PassengerName = updateTicket.PassengerName;
                reserve.ContactNo = updateTicket.ContactNo;
                reserve.Email = updateTicket.Email;
                reserve.NoOfTickets = updateTicket.NoOfTickets;
                reserve.TotalFare = updateTicket.TotalFare;
                reserve.Status = updateTicket.Status;

                BookingUpdated = true;
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return BookingUpdated;
        }

        public bool CancelBookingDAL(int cancelTicket)
        {
            bool cancelbooking = false;
            try
            {
                Reservation deleteB = reservationList.Find(f => f.TicketNo == cancelTicket);

                if (deleteB != null)
                {
                    reservationList.Remove(deleteB);
                    deleteB.Status = "Cancelled";
                    cancelbooking = true;
                }
            }
            catch (DbException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return cancelbooking;
        }

        public List<Reservation> ListBookingDAL()
        {
            return reservationList;
        }
    }
}
