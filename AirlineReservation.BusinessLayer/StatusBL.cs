using AirlineReservation.DataAccessLayer;
using AirlineReservation.Exceptions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.BusinessLayer
{
    public class StatusBL
    {
        public static bool addStatus(Status s)
        {
            bool statusAdded = false;
            try
            {
                StatusDAL statusDAL = new StatusDAL();
                statusAdded = true;
                statusDAL.AddStatusDAL(s);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return statusAdded;
        }

        public bool updateStatus(int reservationId, Status newStatus)
        {
            bool statusUpdated = false;
            try
            {
                StatusDAL statusDAL = new StatusDAL();
                statusUpdated = statusDAL.UpdateStatusDAL(reservationId, newStatus);

            }
            catch (Exception e)
            {
                throw new AirlineReservationException(e.Message);
            }
            return statusUpdated;
        }
        public string viewStatus(int reservationId)
        {
            string current_status = null;
            try
            {
                StatusDAL statusDAL = new StatusDAL();
                current_status = statusDAL.ViewStatusDAL(reservationId);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return current_status;
        }

        public bool deleteStatus(int reservationId)
        {
            bool statusDeleted = false;
            try
            {
                StatusDAL statusDAL = new StatusDAL();
                statusDeleted = statusDAL.DeleteStatusDAL(reservationId);
            }
            catch (Exception e)
            {
                throw new AirlineReservationException("");
            }
            return statusDeleted;
        }

        public List<Status> GetStatusBL()
        {
            List<Status> statuses = new List<Status>();
            try
            {
                StatusDAL statusDAL = new StatusDAL();
                statuses = statusDAL.ListStatusesDAL();
            }
            catch (Exception e)
            {
                throw new AirlineReservationException("");
            }
            return statuses;
        }

    }
}
