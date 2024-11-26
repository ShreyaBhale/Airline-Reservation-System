using AirlineReservation.Exceptions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AirlineReservation.DataAccessLayer;
using AirlineReservation.Exceptions;

namespace AirlineReservation.BusinessLayer
{
    public class FlightBL
    {
        // Validate flight details
        private static bool ValidateFlight(Flight flight)
        {
            StringBuilder sb = new StringBuilder();
            bool validFlight = true;
            if (flight.FlightID <= 0)
            {
                validFlight = false;
                sb.Append(Environment.NewLine + "Invalid Ticket No");
            }

            if (string.IsNullOrWhiteSpace(flight.Origin) || string.IsNullOrWhiteSpace(flight.Destination))
            {
                validFlight = false;
                sb.Append(Environment.NewLine + "Origin and Destination cannot be empty.");
            }

            if (flight.NoOfSeats <= 0)
            {
                validFlight = false;
                sb.Append(Environment.NewLine + "Number of seats must be greater than zero.");
            }

            if (flight.Fare <= 0)
            {
                validFlight = false;
                sb.Append(Environment.NewLine + "Fare must be a positive value.");
            }

            if (flight.DepartureTime >= flight.ArrivalTime)
            {
                validFlight = false;
                sb.Append(Environment.NewLine + "Departure time must be before the arrival time.");
            }
            if(validFlight = false)
            {
                throw new AirlineReservationException(sb.ToString());
            }
            return validFlight;
        }

        // Add a new flight
        public static bool AddFlightBL(Flight flight)
        {
            bool addedflight = false;
            try
            {
                if (ValidateFlight(flight))
                {
                    if (FlightDAL.SearchFlightDAL(flight.FlightID) != null)
                    {
                        throw new AirlineReservationException("Flight ID already exists. Please use a unique ID.");
                    }

                    FlightDAL.AddFlightDAL(flight);
                    addedflight = true;
                }
            }
            catch (AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return addedflight;
           
        }

        // Update an existing flight
        public static bool UpdateFlightBL(Flight updatedFlight)
        {
            bool updatedflight = false;
            ValidateFlight(updatedFlight);
            try 
            {
                if (ValidateFlight(updatedFlight))
                {
                    Flight existingFlight = FlightDAL.SearchFlightDAL(updatedFlight.FlightID);
                    if (existingFlight == null)
                    {
                        throw new AirlineReservationException("Flight ID does not exist.");
                    }

                    FlightDAL.UpdateFlightDAL(updatedFlight);
                    updatedflight = true;
                }
            }
            catch (AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return updatedflight;
        }

        // Delete a flight by its ID
        public static bool DeleteFlightBL(int id)
        {
            bool deleteflight = false;

            try
            {
                if (id > 0)
                {
                    FlightDAL.DeleteFlightDAL(id);
                    deleteflight = true;
                }
                else
                {
                    throw new Exception("Invalid Flight id");
                }
            }
            catch (AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return deleteflight;
        }

        // View a specific flight by its ID
        public static Flight ViewFlightBL(int id)
        {
            Flight flight = null;
            try
            {
                flight = FlightDAL.SearchFlightDAL(id);
            }
            catch(AirlineReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }   

            return flight;
        }

        // List all available flights
        public static List<Flight> ListFlightsBL()
        {
            List<Flight> flights = FlightDAL.ViewAllFlights();
            if (flights.Count == 0)
            {
                throw new AirlineReservationException("No flights available.");
            }

            return flights;
        }
    }
}
