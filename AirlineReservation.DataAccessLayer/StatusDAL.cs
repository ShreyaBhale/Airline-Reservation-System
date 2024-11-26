using AirlineReservation.Exceptions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.DataAccessLayer
{
    public class StatusDAL
    {
        public static List<Status> statusList = new List<Status>();

        // Add a new status
        public bool AddStatusDAL(Status newStatus)
        {
            bool statusAdded = false;
            try
            {
                // Directly add the status
                statusList.Add(newStatus);
                statusAdded = true;
            }
            catch (ApplicationException ex)
            {
                throw new AirlineReservationException("An error occurred while adding the status.", ex);
            }
            return statusAdded;
        }

        // Update an existing status
        public bool UpdateStatusDAL(int ticketNum, Status newStatus)
        {
            bool statusUpdated = false;
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                for (int i = 0; i < reservations.Count; i++)
                {
                    if (reservations[i].TicketNo==ticketNum)
                    {
                        reservations[i].Status = newStatus.ToString();
                        statusUpdated = true;
                        break;
                    }
                }
            }
            catch (ApplicationException ex)
            {
                throw new AirlineReservationException("An error occurred while updating the status.", ex);
            }
            return statusUpdated;
        }

        // Delete a status
        public bool DeleteStatusDAL(int reservationsId)
        {
            List<Reservation> reservations = new List<Reservation>();
            bool statusDeleted = false;
            try
            {
                for (int i = 0; i < reservations.Count; i++)
                {
                    if (reservations[i].Status != null)
                    {
                        reservations[i].Status = null;
                        statusDeleted = true;
                    }

                }

            }
            catch (ApplicationException ex)
            {
                throw new AirlineReservationException("An error occurred while deleting the status.", ex);
            }
            return statusDeleted;
        }

        // View a status
        public string ViewStatusDAL(int ticketNo)
        {
            string foundStatus = null;

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                for (int i = 0; i <= reservations.Count; i++)
                {
                    if (reservations[i].TicketNo == ticketNo)
                    {
                        foundStatus = reservations[i].Status;

                    }
                }

            }
            catch (ApplicationException ex)
            {
                throw new AirlineReservationException("An error occurred while viewing the status.", ex);
            }
            return foundStatus;
        }

        // List all statuses
        public List<Status> ListStatusesDAL()
        {
            try
            {
                return new List<Status>(statusList);
            }
            catch (ApplicationException ex)
            {
                throw new AirlineReservationException("An error occurred while listing statuses.", ex);
            }
        }


    }
}
