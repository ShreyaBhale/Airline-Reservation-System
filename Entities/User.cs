using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int UserId;
        public string UserName;
        public string Role;
        public string Password;
        public string Email;

        public User(int userid, string username, string role, string password, string email)
        {
            this.UserId = userid;
            this.UserName = username;
            this.Role = role;
            this.Password = password;
            this.Email = email;
        }
    }
}
