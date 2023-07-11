using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApp.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public UserModel(int iD, string firstName, string lastName, string username, string password)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Username = username; //${firstName?(0..2)}{lastName?(0..2)}
            Password = password;
            
        }
    }
}
