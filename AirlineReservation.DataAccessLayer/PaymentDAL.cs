using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace AirlineReservation.DataAccessLayer
{
    public class PaymentDAL
    {
        
        public double gst = 0.1;    

        public static double CalculateTotalFare(int flightid, int numoftickets)
        {
            Flight f = FlightDAL.SearchFlightDAL(flightid);
            double Totalfare = f.Fare;
            Totalfare = (Totalfare + (Totalfare * 0.1)) * numoftickets;
            return Totalfare;
        }

        public static double RefundDAL(int flightid, int numoftickets)
        {
            Flight f = FlightDAL.SearchFlightDAL(flightid);
            double Totalfare = f.Fare * numoftickets;
            double refund = Totalfare - (Totalfare * 0.6);
            return refund;
        }
    }
}
