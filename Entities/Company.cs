using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string contactNo { get; set; }

        public Company(int id, string name, string contactnumber)
        {
            this.Id = id;
            this.Name = name;
            this.contactNo = contactnumber;
        }
    }
}
