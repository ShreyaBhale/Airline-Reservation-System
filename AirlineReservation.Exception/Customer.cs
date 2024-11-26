using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.Exception
{
    internal class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }

        public Customer(int id, string name, string contactNo, string address)
        {
            this.id = id;
            this.name = name;
            this.contactNo = contactNo;
            this.address = address;
        }

    }
}
