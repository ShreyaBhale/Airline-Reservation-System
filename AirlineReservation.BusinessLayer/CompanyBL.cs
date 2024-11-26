using AirlineReservation.DataAccessLayer;
using AirlineReservation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.DataAccessLayer;
using Entities;
using System.Data.Common;

namespace AirlineReservation.BusinessLayer
{
    public class CompanyBL
    {
        

        public static bool AddCompanyBL(Company new_company)
        {
            bool added = false;
            try
            {
                if (ValidateCompany(new_company))
                {
                    added = CompanyDAL.AddCompany(new_company);
                }
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return added;
        }

        public static Company SearchCompanyBL(int id)
        {
            Company searchCompany = null;
            try
            {
                searchCompany = CompanyDAL.SearchCompanyDAL(id);
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return searchCompany;
        }

        public static bool UpdateCompanyBL(Company updatedCompany)
        {
            bool updated = false;
            try
            {
                if (ValidateCompany(updatedCompany))
                {
                    updated = CompanyDAL.UpdateCompanyName(updatedCompany);
                }
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return updated;
        }

        public static bool DeleteCompanyBL(Company deleteCompany)
        {
            bool deleted = false;
            try
            {
                deleted = CompanyDAL.DeleteCompanyDAL(deleteCompany);
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return deleted;
        }

        public static List<Company> ListCompaniesBL()
        {
            List<Company> companies = null;
            try
            {
                companies = CompanyDAL.ListBookingDAL();
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return companies;
        }

        private static bool ValidateCompany(Company company)
        {
            bool isValid = true;

            if (company.Id <= 0)
            {
                isValid = false;
                throw new AirlineReservationException("Invalid Company ID.");
            }
            if (string.IsNullOrWhiteSpace(company.Name))
            {
                isValid = false;
                throw new AirlineReservationException("Company Name cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(company.contactNo) || company.contactNo.Length != 10)
            {
                isValid = false;
                throw new AirlineReservationException("Invalid Contact Number.");
            }

            return isValid;
        }
    }
}
