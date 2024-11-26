using AirlineReservation.Exceptions;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace AirlineReservation.DataAccessLayer
{
    public class CompanyDAL
    {

        public static List<Company> company_name = new List<Company>();

        static CompanyDAL(){}
    
        public static bool AddCompany(Company new_company)
        {
            //company_name.Add("Indigo");
            //company_name.Add("AirIndia");
            //company_name.Add("Vistara");

            bool added = false;
            try
            {
                company_name.Add(new_company);
                added = true;
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return added;
        }

        public static Company SearchCompanyDAL(int id)
        {
            Company searchcompany = null;
            try
            {
                searchcompany = company_name.Find(c => c.Id == id);
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return searchcompany;
        }

        public static bool UpdateCompanyName(Company updatecompany)
        {
            bool BookingUpdated = false;
            try
            {
                Company comp = SearchCompanyDAL(updatecompany.Id);
                if (comp.Id == updatecompany.Id)
                {
                    comp.Name = updatecompany.Name;
                    comp.contactNo = updatecompany.contactNo;
                    BookingUpdated = true;
                }
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return BookingUpdated;
        }

        public static bool DeleteCompanyDAL(Company deletecompany)
        {
            bool deleted = false;
            try
            {
                Company comp = SearchCompanyDAL(deletecompany.Id);
                company_name.Remove(comp);
                deleted = true;

            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return deleted;
        }

        public static List<Company> ListBookingDAL()
        {
            return company_name;
        }
    }

}
