using AirlineReservation.DataAccessLayer;
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
    public class CityBL
    {
        public static bool validCity(City City)
        {
            StringBuilder sb = new StringBuilder();
            bool cityValid = true;
            if (City == null || City.Name == string.Empty)
            {
                cityValid = false;
                sb.Append(Environment.NewLine + "City is invalid");
            }
            return cityValid;

        }

        public static bool AddCityBL(City city)
        {
            bool cityAdded = false;
            try
            {
                if (validCity(city))
                {
                    CityDal dALClass = new CityDal();
                    cityAdded = true;
                    dALClass.AddCityDAL(city);
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return cityAdded;

        }

        public static bool updateCityBL(City oldCity,City city)
        {
            bool cityUpdated = false;
            try
            {
                if (validCity(city))
                {
                    CityDal dALClass = new CityDal();
                    cityUpdated = true;
                    cityUpdated = dALClass.UpdateCityDAL(oldCity.Name,city.Name);
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return cityUpdated;
        }

        public static bool deleteCityBL(string deleteName)
        {
            bool cityDeleted = false;
            try
            {
                
                    CityDal dALClass = new CityDal();
                    
                    cityDeleted = true;
                    dALClass.DeleteCityDAL(deleteName);
                
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return cityDeleted;

        }
        public static List<City> listCityBL()
        {
            List<City> cityList = null;
            try
            {
                cityList = CityDal.ViewListDAL();
            }
            catch (Exception ex)
            {
                throw new AirlineReservationException(ex.Message);
            }
            return cityList;
        }
    }
}
