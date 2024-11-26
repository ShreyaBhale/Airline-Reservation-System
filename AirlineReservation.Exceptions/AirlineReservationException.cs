using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.Exceptions
{
    public class AirlineReservationException : ApplicationException
    {
        public AirlineReservationException()
            : base()
        {
            //Logic to log exception in a flat file
        }

        public AirlineReservationException(string message)
            : base(message)
        {
            //Logic to log exception in a db
        }
        public AirlineReservationException(string message, Exception innerException)
            : base(message, innerException)
        {
            //Logic to log exception in an xml file
        }
    }
}
