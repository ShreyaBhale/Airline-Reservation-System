using AirlineReservation.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace AirlineReservation.DataAccessLayer
{
    public class CityDal
    {
        public static List<City> city_names = new List<City>();

        static CityDal(){}

        public bool AddCityDAL(City new_city)
        {

            bool added = false;
            try
            {
                city_names.Add(new_city);
                added = true;
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return added;
        }

        public City SearchCityDAL(string city)
        {
            City searchcity = null;
            try
            {
                searchcity = city_names.Find(c => c.Name == city);
                
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return searchcity;
        }

        public bool UpdateCityDAL(string oldName,string updatename)
        {
            bool CityUpdated = false;
            try
            {
                City city = SearchCityDAL(oldName);
                city.Name = updatename;
                CityUpdated = true;
            }
            catch (SystemException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return CityUpdated;
        }

        public bool DeleteCityDAL(string deletename)
        {
            bool deleted = false;
            try
            {
                City city = SearchCityDAL(deletename);
                city_names.Remove(city);
                deleted = true;

            }
            catch (DbException ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return deleted;
        }

        public static List<City> ViewListDAL()
        {
            return city_names;
        }
    }
}
