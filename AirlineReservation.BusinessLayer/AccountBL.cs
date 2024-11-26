using AirlineReservation.DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.BusinessLayer
{
    public class AccountBL
    {

        public bool LoginBL(string username, string password)
        {


            StringBuilder sb= new StringBuilder();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {

                return false;
            }
            bool user = Authenticate(username, password);
           // Console.WriteLine("User: {0}",user);

            if (user != null)
            {
                sb.AppendLine(Environment.NewLine+"Login Successfull");
                return true;
            }
            else
            {
                sb.AppendLine(Environment.NewLine+"Invalid Username or Password");
                return false;
            }
        }
        AccountsDAL accountsDAL = new AccountsDAL();
        
        public bool Authenticate(string username, string password)
        {
            var users = accountsDAL.getUsers();
            
            
            var userExists= users.Any(u => u.UserName.Equals(username,StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password));
           // Console.WriteLine("User1: {0}", userExists);
           
            return userExists;
        }

        public bool RegisterBL(String username, string password, string confirmPassword, string email)
        {
            var users= accountsDAL.getUsers();
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                sb.AppendLine(Environment.NewLine + "Username, Email and Password are required");

                return false;

            }
            if (password != confirmPassword)
            {
                sb.AppendLine(Environment.NewLine + "Passwords do not match!");

                return false;
            }
            if (users.Any(u => u.UserName.Equals(username)))
            {
                sb.AppendLine(Environment.NewLine + "Username already exists.");

                return false;
            }
            //users.Add(new User { UserName = username, Password = password, Email = email });
            return true;

        }

        /*public bool RegisterAdminBL(string currentAdminUsername, string newAdminUsername, string password, string confirmPassword, string email)
        {
            StringBuilder sb = new StringBuilder();
            var currentAdmin = users.FirstOrDefault(u => u.UserName.Equals(currentAdminUsername) && u.Role == "admin");

            if (currentAdmin == null)
            {
                sb.AppendLine(Environment.NewLine+"Only an admin can register another admin");
               
                return false;
            }
            if (string.IsNullOrWhiteSpace(currentAdminUsername) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                sb.AppendLine(Environment.NewLine + "Username, Password and Email are required");
                return false;
            }
            if (password != confirmPassword)
            {
                sb.AppendLine(Environment.NewLine + "Passwords do not match!");
                
                return false;
            }
            if (users.Any(u => u.UserName.Equals(newAdminUsername)))
            {
                sb.AppendLine(Environment.NewLine + "Username already exists.");
                
                return false;
            }
            //users.Add(new User { UserName = newAdminUsername, Password = password, Email = email, Role = "admin" });
            sb.AppendLine(Environment.NewLine + "Admin User added");

            return true;
        }*/
    }
}
