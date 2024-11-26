using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.DataAccessLayer;
using Entities;
using AirlineReservation.Exceptions;

namespace AirlineReservation.BusinessLayer
{
    public class AirReservationBL
    {
        public static bool validReservation(Reservation reservation)
        {
            StringBuilder sb = new StringBuilder();
            bool validRes = true;
            if (reservation.TicketNo <= 0)
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Invalid Ticket No");
            }
            if (reservation.DateOfBooking == null)
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Enter date!");
            }
            if (reservation.JourneyDate == null)
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Enter Journey date!");
            }
            if ((reservation.PassengerName) == String.Empty)
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Enter Passenger Name");
            }
            if (reservation.ContactNo == null || reservation.ContactNo.Length > 10)
            {

                validRes = false;
                sb.Append(Environment.NewLine + "Contact number is not valid");

            }
            if (reservation.Email == null)
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Email is not valid");
            }
            if (reservation.NoOfTickets <= 0)
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Number of tickets must be greater than 0");
            }
            if (reservation.Status == null )
            {
                validRes = false;
                sb.Append(Environment.NewLine + "Status is Invalid!");
            }
            if (validRes == false)
            {
                throw new AirlineReservationException(sb.ToString());
            }
            return validRes;
        }

        public static bool BookTicketBL(Reservation reservation)
        {
            bool ticketBooked = false;
            try
            {
                if (validReservation(reservation))
                {
                    ReservationDAL dalClass = new ReservationDAL();
                    dalClass.BookTicket(reservation);
                    ticketBooked = true;
                }
            }
            catch (AirlineReservationException ex)
            {
                 Console.WriteLine(ex.Message);//change to AirlineException
            }
            return ticketBooked;
        }

        public static bool updateTicketBL(Reservation UpdateReservation)
        {
            bool updatedTicket = false;
            try
            {

                if (validReservation(UpdateReservation))
                {
                    ReservationDAL dALClass = new ReservationDAL();

                    updatedTicket = dALClass.UpdateBookingDAL(UpdateReservation);
                }
            }
            catch (AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return updatedTicket;
        }

        public static bool cancelReservationBL(int cancelReservationID)
        {
            bool cancelled = false;
            try
            {
                if (cancelReservationID > 0)
                {

                    ReservationDAL dalClass = new ReservationDAL();
                    cancelled = dalClass.CancelBookingDAL(cancelReservationID);
                }
                else
                {
                    throw new Exception("Invalid reservation ID");
                }
            }
            catch(AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cancelled;
        }

        public static Reservation ViewBookingBL(int res_id)
        {
            Reservation viewRes = null;
            try
            {
                ReservationDAL dalClass = new ReservationDAL();
                viewRes = dalClass.SearchTicketDAL(res_id);
            }
            catch (AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return viewRes;
        }

        public static List<Reservation> getReservationList()
        {
            List<Reservation> Reservationlist = new List<Reservation>();
            try
            {
                ReservationDAL dalClass = new ReservationDAL();
                Reservationlist = dalClass.ListBookingDAL();
            }
            catch (AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Reservationlist;
        }


    }
}
