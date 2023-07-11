using AuthenticationApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApp.Interface
{
    public interface IAuthentication
    {
        public void CreateUser(UserModel userModel);
        public void EditUser(int userID);
        public void DeleteUser(int userID);
        public void ShowUser(UserModel userModel);
        public UserModel SearchUser(string username);
        bool LoginUser(string username, string password);

    }
}
