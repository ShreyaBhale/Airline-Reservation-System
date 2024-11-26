using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.DataAccessLayer
{
    public class AccountsDAL
    {

        public List<User> users = new List<User>
        {
            new User(1,"Raju","admin","Raju@123","raju@gmail.com"),
            new User(2,"Shweta","customer","shweta@123","shweta@gmail.com"),
            new User(3,"Suraj","customer","suraj@123","suraj@gmail.com"),
            new User(4,"Pranay","customer","pranay@123","pranay@gmail.com"),
            new User(5,"Shreya","customer","shreya@123","shreya@gmail.com")
        };
        public List<User> getUsers() {  return users; }
        public bool LoginDAL(string username, string password)
        {
            StringBuilder sb = new StringBuilder();
            bool authenticatedUser = false;
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            try
            {
                if (user != null)
                {
                    sb.Append("Login Successful!");
                    authenticatedUser = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return authenticatedUser;

        }

        public bool LoginAdminDAL(string username, string password)
        {
            StringBuilder sb = new StringBuilder();
            bool authenticatedAdminUser = false;
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password && u.Role=="admin");
            try
            {
                if (user != null)
                {
                    sb.Append("Login Successful!");
                    authenticatedAdminUser = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return authenticatedAdminUser;

        }

        public bool RegistrationDAL(int userid,string username, string password, string confirmPassword, string email)
        {
            bool successfullRegistration = false;
            try
            {
                User newUser= new User(userid,username,password,confirmPassword,email);
                users.Add(newUser);
                successfullRegistration = true;
            }
            catch (Exception ex)
            {
                //throw new Exception
            }
            return successfullRegistration;
        }

       /* public bool RegistrationAdminDAL(User user, User adminUser)
        {
            bool successfullAdminRegistration = false;
            try
            {
                if (adminUser.Role == "admin")
                {
                    users.Add(new User { UserId = user.UserId, UserName = user.UserName, Password = user.Password, Email = user.Email, Role = adminUser.Role });
                    successfullAdminRegistration = true;

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return successfullAdminRegistration;
        }*/


    }
}
