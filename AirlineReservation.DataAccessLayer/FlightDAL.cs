using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.Exceptions;
using Entities;

namespace AirlineReservation.DataAccessLayer
{
    public class FlightDAL
    {
        public static List<Flight> flightList = new List<Flight>();

        static FlightDAL()
        {
            flightList.Add(new Flight
            {
                FlightID = 1,
                LaunchDate = new DateTime(),
                Origin = "New York",
                Destination = "Los Angeles",
                DepartureTime = new DateTime(2024, 09, 11, 04, 20, 26),
                ArrivalTime = new DateTime(2024, 09, 11, 07, 30, 20),
                NoOfSeats = 150,
                Fare = 30000
            });

            flightList.Add(new Flight
            {
                FlightID = 2,
                LaunchDate = new DateTime(2024, 08, 11),
                Origin = "Chicago",
                Destination = "San Francisco",
                DepartureTime = new DateTime(2024, 09, 11, 04, 20, 26),
                ArrivalTime = new DateTime(2024, 09, 11, 07, 30, 20),
                NoOfSeats = 200,
                Fare = 40000
            });

        }



        public static bool AddFlightDAL(Flight newFlight)
        { 
            bool flightAdded = false;
            try
            {
                flightList.Add(newFlight);
                flightAdded = true;
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return flightAdded;
        }

        public static bool UpdateFlightDAL(Flight updatedflight)
        {
            bool flightUpdated = false;
            try
            {
                Flight flight = SearchFlightDAL(updatedflight.FlightID);

                    if (flight.FlightID == updatedflight.FlightID)
                    {
                        flight.LaunchDate = updatedflight.LaunchDate;
                        flight.Origin = updatedflight.Origin;
                        flight.Destination = updatedflight.Destination;
                        flight.DepartureTime = updatedflight.DepartureTime;
                        flight.ArrivalTime = updatedflight.ArrivalTime;
                        flight.NoOfSeats = updatedflight.NoOfSeats;
                        flight.Fare = updatedflight.Fare;

                        flightUpdated = true;
                        
                    }
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return flightUpdated;
        }

        public static bool DeleteFlightDAL(int deleteflightID)
        {
            bool deleted = false;
            try
            {
                Flight deleteF = SearchFlightDAL(deleteflightID);

                if (deleteF != null)
                {
                    flightList.Remove(deleteF);
                    deleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return deleted;
        }

        public static Flight SearchFlightDAL(int searchflightID)
        {
            Flight searchflight = null;
            try
            {
                searchflight = flightList.Find(f => f.FlightID == searchflightID);
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return searchflight;
        }

        public static List<Flight> ViewAllFlights()
        {
            return flightList;
        }
    }
}
