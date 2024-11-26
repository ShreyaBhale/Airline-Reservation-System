using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using AirlineReservation.BusinessLayer;
using AirlineReservation.DataAccessLayer;

namespace AirlineReservation.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var flightService = new FlightService();
            //var reservationService = new ReservationService();

            while (true)
            {
                Console.WriteLine("\nWelcome to the Airline Reservation System");
                Console.WriteLine("1. Administrator");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Exit");
                Console.Write("Select your role (1, 2, or 3): ");
                var role = Console.ReadLine();

                if (role == "1")
                {
                    AdminLogin();
                }
                else if (role == "2")
                {
                    LoginRegister();
                }
                else if (role == "3")
                {
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            Console.ReadKey();
        }

        static void AdminLogin()
        {
            Console.WriteLine("Admin Login");
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            AccountBL accountBL = new AccountBL();
            bool login = accountBL.LoginBL(username, password);
            if (login)
            {
                   AccountsDAL accountsDAL = new AccountsDAL();
                   bool loggedIn = accountsDAL.LoginAdminDAL(username, password);
                   if (loggedIn)
                    {
                     AdministratorMenu();
                    }
                   
            }                 

            
        }
        static void LoginRegister()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Username: ");

                    string username = Console.ReadLine();

                    Console.WriteLine("Enter Password: ");

                    string password = Console.ReadLine();
                    AccountBL accountBL = new AccountBL();
                    
                    bool login = accountBL.LoginBL(username, password);
                    if (login)
                    {
                       // Console.WriteLine("Account BL done!");
                        AccountsDAL accountsDAL = new AccountsDAL();
                        bool loggedIn = accountsDAL.LoginDAL(username, password);
                        if (loggedIn)
                        {
                            CustomerMenu();
                        }
                    }

                    break;

                case 2:
                    Console.WriteLine("Enter user_id: ");
                    int user_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Username: ");
                    string username1 = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password1 = Console.ReadLine();
                    Console.WriteLine("Re-Enter Password: ");
                    string rePassword = Console.ReadLine();
                    Console.WriteLine("Enter Email: ");
                    string email = Console.ReadLine();

                    AccountBL accountBL1 = new AccountBL();
                    bool validData = accountBL1.RegisterBL(username1, password1, rePassword, email);
                    if (validData)
                    {
                        AccountsDAL accountsDAL1 = new AccountsDAL();
                        bool isRegistered = accountsDAL1.RegistrationDAL(user_id,username1, password1, rePassword, email);
                        if (isRegistered)
                        {
                            CustomerMenu();
                        }
                    }

                    break;

                default:
                    Console.WriteLine("Choose the right option!");
                    Environment.Exit(0);
                    break;

            }


        }

        static void AdministratorMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdministrator Menu:");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. Update Flight");
                Console.WriteLine("3. Delete Flight");
                Console.WriteLine("4. View Flight");
                Console.WriteLine("5. List All Flights");
                Console.WriteLine("6. Open Company Menu");
                Console.WriteLine("7. Open City Menu");
                Console.WriteLine("8. Exit");
                Console.Write("Select an action (1-8): ");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        AddFlightPL();
                        break;
                    case "2":
                        UpdateFlightPL();
                        break;
                    case "3":
                        DeleteFlightPL();
                        break;
                    case "4":
                        ViewFlightPL();
                        break;
                    case "5":
                        ListFlightsPL();
                        break;
                    case "6":
                        companyMenu();
                        break;
                    case "7":
                        CityMenu();
                        break;
                    case "8":
                        
                        return;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }

        static void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\nCustomer Menu:");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Update Booking");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. View Booking");
                Console.WriteLine("5. List All Bookings");
                Console.WriteLine("6. Exit");
                Console.Write("Select an action (1-6): ");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        BookTicketPL();
                        break;
                    case "2":
                        UpdateBookingPL();
                        break;
                    case "3":
                        CancelReservationPL();
                        break;
                    case "4":
                        ViewBookingPL();
                        break;
                    case "5":
                        ListBookingsPL();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }

        // Administrator Presentation Layer (PL)
        static void AddFlightPL()
        {
            var flight = new Flight();

            Console.Write("Enter Flight ID: ");
            flight.FlightID = int.Parse(Console.ReadLine());
            Console.Write("Enter Launch Date (yyyy-mm-dd): ");
            flight.LaunchDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Origin: ");
            flight.Origin = Console.ReadLine();
            Console.Write("Enter Destination: ");
            flight.Destination = Console.ReadLine();
            Console.Write("Enter Departure Time (hh:mm): ");
            flight.DepartureTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Arrival Time (hh:mm): ");
            flight.ArrivalTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Number of Seats: ");
            flight.NoOfSeats = int.Parse(Console.ReadLine());
            Console.Write("Enter Fare: ");
            flight.Fare = double.Parse(Console.ReadLine());

            bool flightAdded = FlightBL.AddFlightBL(flight);
            if (flightAdded)
            {
                Console.WriteLine("Flight added successfully.");
            }
            else
            {
                Console.WriteLine("Flight Not Added");
            }
        }

        static void UpdateFlightPL()
        {
            Console.Write("Enter Flight ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Flight fupdate = new Flight();
            Console.Write("Enter Launch Date (yyyy-mm-dd): ");
            fupdate.LaunchDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Origin: ");
            fupdate.Origin = Console.ReadLine();
            Console.Write("Enter Destination: ");
            fupdate.Destination = Console.ReadLine();
            Console.Write("Enter Departure Time (hh:mm): ");
            fupdate.DepartureTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Arrival Time (hh:mm): ");
            fupdate.ArrivalTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Number of Seats: ");
            fupdate.NoOfSeats = int.Parse(Console.ReadLine());
            Console.Write("Enter Fare: ");
            fupdate.Fare = double.Parse(Console.ReadLine());

            bool updatef = FlightBL.UpdateFlightBL(fupdate);
            if(updatef)
            {
                Console.WriteLine("Flight launch date updated successfully.");
            }
            else
            {
                Console.WriteLine("Flight details were not added, please try again");
            }
        }

        static void DeleteFlightPL()
        {
            Console.Write("Enter Flight ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            bool deletetedflight = FlightBL.DeleteFlightBL(id);

            Console.WriteLine("Flight deleted successfully.");
        }

        static void ViewFlightPL()
        {
            Console.Write("Enter Flight ID to view: ");
            int id = int.Parse(Console.ReadLine());

            var flight = FlightBL.ViewFlightBL(id);
            if (flight != null)
            {
                Console.WriteLine($"ID: {flight.FlightID}, Launch Date: {flight.LaunchDate}, Origin: {flight.Origin}, Destination: {flight.Destination}, Departure Time: {flight.DepartureTime}, Arrival Time: {flight.ArrivalTime}, No. of Seats: {flight.NoOfSeats}, Fare: {flight.Fare}");
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        static void ListFlightsPL()
        {
            List<Flight> flights = FlightBL.ListFlightsBL();
            if (flights.Any())
            {
                foreach (var flight in flights)
                {
                    Console.WriteLine($"ID: {flight.FlightID}, Launch Date: {flight.LaunchDate}, Origin: {flight.Origin}, Destination: {flight.Destination}, Departure Time: {flight.DepartureTime}, Arrival Time: {flight.ArrivalTime}, No. of Seats: {flight.NoOfSeats}, Fare: {flight.Fare}");
                }
            }
            else
            {
                Console.WriteLine("No flights available.");
            }
        }

        // Customer Presentation Layer (PL)
        static void BookTicketPL()
        {
            var reserve = new Reservation();

            Console.Write("Enter Ticket No: ");
            reserve.TicketNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Flight ID: ");
            reserve.FlightId = int.Parse(Console.ReadLine());
            reserve.DateOfBooking = DateTime.Now;
            Console.Write("Enter Journey Date (yyyy-mm-dd): ");
            reserve.JourneyDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Passenger Name: ");
            reserve.PassengerName = Console.ReadLine();
            Console.Write("Enter Contact No: ");
            reserve.ContactNo = Console.ReadLine();
            Console.Write("Enter Email: ");
            reserve.Email = Console.ReadLine();
            Console.Write("Enter Number of Tickets: ");
            reserve.NoOfTickets = int.Parse(Console.ReadLine());
            reserve.Status = "Booked";

            bool booked = AirReservationBL.BookTicketBL(reserve);
            Console.WriteLine("Your Total Fare is: " + reserve.TotalFare);
            if (booked)
            {
                Console.WriteLine("Ticket booked successfully.");
            }
            else
            {
                Console.WriteLine("Ticket was not booked, Try again");
            }
        }

        static void UpdateBookingPL()
        {
            Console.Write("Enter Ticket No to update: ");
            int ticketNo = int.Parse(Console.ReadLine());

            Reservation updatebooking = AirReservationBL.ViewBookingBL(ticketNo);
            Console.Write("Enter new Journey Date(yyyy-mm-dd): ");
            updatebooking.JourneyDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Passenger Name: ");
            updatebooking.PassengerName = Console.ReadLine();
            Console.Write("Enter Contact No: ");
            updatebooking.ContactNo = Console.ReadLine();
            Console.Write("Enter Email: ");
            updatebooking.Email = Console.ReadLine();
            Console.Write("Enter Number of Tickets: ");
            updatebooking.NoOfTickets = int.Parse(Console.ReadLine());

            bool updated = AirReservationBL.updateTicketBL(updatebooking);
            if (updated)
            {
                Console.WriteLine("Booking updated successfully.");
            }
            else { 
                Console.WriteLine("Booking not updated, try again.");
            }
        }

        static void CancelReservationPL()
        {
            Console.Write("Enter Ticket No to cancel: ");
            int ticketNo = int.Parse(Console.ReadLine());


            Reservation r = AirReservationBL.ViewBookingBL(ticketNo);
            bool canceledticket = AirReservationBL.cancelReservationBL(ticketNo);

            if(canceledticket)
            {
                Console.WriteLine("Reservation cancelled successfully.");
                double refund = PaymentDAL.RefundDAL(r.FlightId, r.NoOfTickets);
                Console.WriteLine("Ammount Refunded: " + refund);
            }
            else
            {
                Console.WriteLine("Reservation was not cancelled, try again");
            }
        }

        static void ViewBookingPL()
        {
            Console.Write("Enter Ticket No to view: ");
            int ticketNo = int.Parse(Console.ReadLine());

            var reservation = AirReservationBL.ViewBookingBL(ticketNo);
            if (reservation != null)
            {
                Console.WriteLine($"Ticket No: {reservation.TicketNo}, Flight ID: {reservation.FlightId}, Date of Booking: {reservation.DateOfBooking}, Journey Date: {reservation.JourneyDate}, Passenger Name: {reservation.PassengerName}, Contact No: {reservation.ContactNo}, Email: {reservation.Email}, No. of Tickets: {reservation.NoOfTickets}, Total Fare: {reservation.TotalFare}, Status: {reservation.Status}");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }

        static void ListBookingsPL()
        {
            var reservations = AirReservationBL.getReservationList();
            if (reservations.Any())
            {
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Ticket No: {reservation.TicketNo}, Flight ID: {reservation.FlightId}, Date of Booking: {reservation.DateOfBooking}, Journey Date: {reservation.JourneyDate}, Passenger Name: {reservation.PassengerName}, Contact No: {reservation.ContactNo}, Email: {reservation.Email}, No. of Tickets: {reservation.NoOfTickets}, Total Fare: {reservation.TotalFare}, Status: {reservation.Status}");
                }
            }
            else
            {
                Console.WriteLine("No bookings available.");
            }
        }

        static void companyMenu()
        {
            Console.WriteLine("\nCompany Menu");
            Console.WriteLine("1. Add Company");
            Console.WriteLine("2. Update Company");
            Console.WriteLine("3. Search Company");
            Console.WriteLine("4. Delete Company");
            Console.WriteLine("5. List Company");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Select option(1-6)");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCompanyPL();                    
                    break;
                case "2":
                    updateCompanyPL();
                    break;
                case "3":
                    searchCompanyPL();
                    break;
                case "4":
                    deleteCompanyPL(); 
                    break;
                case "5":
                    listCompanyPL(); 
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid value entered");
                    break;
            }
        }

        static void AddCompanyPL()
        {
            Console.WriteLine("Enter Company Id: ");
            int companyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Company Name: ");
            string companyName = Console.ReadLine();
            Console.WriteLine("Enter Company Ph No. : ");
            string phoneNo = Console.ReadLine();

            Company newCompany = new Company(companyId, companyName, phoneNo);

            bool companyAdded = CompanyBL.AddCompanyBL(newCompany);
            if (companyAdded)
            {
                Console.WriteLine("Company Added Successfully!");
            }
            else { Console.WriteLine("Company Add Failed"); }
        }

        static void updateCompanyPL()
        {
            Console.WriteLine("Enter id of company to update: ");
            int companyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Company Name: ");
            string newCompany = Console.ReadLine();
            Console.WriteLine("Enter new Contact No:");
            string phoneNo = Console.ReadLine();

            Company newCompany1 = new Company(companyId, newCompany, phoneNo);

            bool companyUpdated = CompanyBL.UpdateCompanyBL(newCompany1);
            if (companyUpdated)
            {
                Console.WriteLine("Company details updated successfully!");
            }
            else
            {
                Console.WriteLine("Company details updation failed!");
            }
        }

        static void searchCompanyPL()
        {
            Console.WriteLine("Enter Company Id to search: ");
            int companyId = int.Parse(Console.ReadLine());

            Company company = CompanyBL.SearchCompanyBL(companyId);
            if (company != null)
            {
                Console.WriteLine("Company Name: {0}, Company Contact No: {1})", company.Name, company.contactNo);
            }
            else
            {
                Console.WriteLine("Company Not Found!");
            }
        }

        static void deleteCompanyPL()
        {
            Console.WriteLine("Enter Id of Company to be deleted: ");
            int companyId = int.Parse(Console.ReadLine());

            Company newCompany = new Company(companyId, "", "");

            bool companyDeleted = CompanyBL.DeleteCompanyBL(newCompany);

            if (companyDeleted)
            {
                Console.WriteLine("Company Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Company delete failed!");
            }
        }

        static void listCompanyPL()
        {
            var companies = CompanyBL.ListCompaniesBL();
            if (companies.Any())
            {
                foreach (var company in companies)
                {
                    Console.WriteLine($"Company Id: {company.Id} , Company Name: {company.Name}, Contact Number: {company.contactNo}");
                }
            }
            else
            {
                Console.WriteLine("No companies available!");
            }
        }

        static void CityMenu()
        {
            Console.WriteLine("City Menu");
            Console.WriteLine("1.Add City");
            Console.WriteLine("2.Update City");
            Console.WriteLine("3.Delete City");
            Console.WriteLine("4.List Cites");
            Console.WriteLine("5.Exit");

            Console.WriteLine("Select an action (1-5): ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    addCityPL();
                    break;
                case "2":
                    updateCityPL();
                    break;
                case "3":
                    deleteCityPL(); 
                    break;
                case "4":
                    listCitiesPL();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Enter value between 1-5");
                    break;
            }
        }

        static void addCityPL()
        {
            Console.WriteLine("Enter City Name: ");
            string newCity = Console.ReadLine();

            City city = new City(newCity);

            bool cityAdded = CityBL.AddCityBL(city);

            if (cityAdded)
            {
                Console.WriteLine("City Added successfully!");
            }
            else
            {
                Console.WriteLine("City Add Failed");
            }
        }
        static void updateCityPL()
        {
            Console.WriteLine("Enter city name to update: ");
            string oldCity = Console.ReadLine();
            Console.WriteLine("Enter updated city name: ");
            string newCity = Console.ReadLine();

            City oldCity1 = new City(oldCity);
            City newCity1 = new City(newCity);

            bool cityUpdated = CityBL.updateCityBL(oldCity1, newCity1);
            if (cityUpdated)
            {

                Console.WriteLine("City Name updated successfully!");
            }
            else
            {
                Console.WriteLine("City Update Failed!");
            }
        }
        static void deleteCityPL()
        {
            Console.WriteLine("Enter city name to delete: ");
            string city = Console.ReadLine();

            bool cityDeleted = CityBL.deleteCityBL(city);
            if (cityDeleted)
            {
                Console.WriteLine("City deleted successfully!");
            }
            else
            {
                Console.WriteLine("City delete failed!");
            }
        }
        static void listCitiesPL()
        {
            var cities = CityBL.listCityBL();
            foreach (var city in cities)
            {
                Console.WriteLine($"City Name:{city.Name} ");
            }
        }

    }
}

