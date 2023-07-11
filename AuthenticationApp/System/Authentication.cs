using AuthenticationApp.Interface;
using AuthenticationApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApp.System
{
    public class Authentication : IAuthentication
    {

        private static int LastID = 0; //ID dibuat 0 agar menjadi increament +1 jika di insert data
        private List<UserModel> user; //dibuat list untuk menampung inputan dari user

        public Authentication()
        {
            user = new List<UserModel>();
        }

        public void CreateUser(UserModel userModel) // Method tambah data atau create user baru
        {
            if (IsValidPassword(userModel.Password))
            {
                userModel.ID = ++LastID; // ID increament +1 otomatis
                user.Add(userModel);
                Console.WriteLine("================================");
                Console.WriteLine("User Created Succesfully");
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("User Created Failed");
            }
        }

        public void CreateUserFromInput() // Method CreateUser menerima inputan dari user
        {
            try
            {
                Console.WriteLine("Enter Firstname: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter Lastname: ");
                string lastName = Console.ReadLine();


                string username;
                username = GenerateUsername(firstName, lastName);

                string password;
                do
                {
                    Console.WriteLine("Enter your password (minimal 8 character, 1 capital letter and 1 number): ");
                    password = Console.ReadLine();
                }
                while (!IsValidPassword(password));

                //untuk menghandle inputan kosong
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception();
                }

                UserModel newUser = new UserModel(0, firstName, lastName, username, password);
                CreateUser(newUser);

            }
            catch
            {
                Console.WriteLine("================================");
                Console.WriteLine("Create user failed, value cannot be null");
                Console.WriteLine("================================");
            }

        }

        public void EditUser(int userID)  // Method edit data User
        {
            UserModel UserExist = user.FirstOrDefault(u => u.ID == userID);

            if (UserExist != null)
            {
                Console.WriteLine($"Edit User with ID {userID}");

                Console.WriteLine("New Firstname : ");
                string newFirstName = Console.ReadLine();
                UserExist.FirstName = newFirstName;

                Console.WriteLine("New Lastname: ");
                string newLastName = Console.ReadLine();
                UserExist.LastName = newLastName;

                Console.WriteLine("New Password: ");
                string newPassword = Console.ReadLine();
                UserExist.Password = newPassword;

                Console.WriteLine("================================");
                Console.WriteLine("User has changed succesfully.");
                Console.WriteLine("================================");
            }

        }

        public void DeleteUser(int userID) // Method delete data user
        {
            UserModel UserExist = user.FirstOrDefault(u => u.ID == userID);
            if (UserExist != null)
            {
                Console.WriteLine($"Are you sure want to delete this {userID}? (y/n)"); //Pilihan opsi agar tidak langsung terhapus oleh user
                string confirm = Console.ReadLine();

                if (confirm.ToLower() == "y")
                {
                    user.Remove(UserExist);
                    Console.WriteLine("================================");
                    Console.WriteLine("User was deleted");
                    Console.WriteLine("================================");
                }
                else
                {
                    Console.WriteLine("Cancel delete");
                }
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("User ID was not found");
                Console.WriteLine("================================");
            }
        }

        public void ShowUser(UserModel userModel) // Method untuk menampilkan semua data user
        {
            Console.WriteLine("Information of User:");
            Console.WriteLine("================================");
            Console.WriteLine($"ID: {userModel.ID}");
            Console.WriteLine($"Name: {userModel.FirstName} {userModel.LastName}");
            Console.WriteLine($"Username: {userModel.Username}");
            Console.WriteLine($"Password: {userModel.Password}");
            Console.WriteLine("================================");
            Console.WriteLine();
        }

        public void ShowAllUsers() // Method yang menampilkan semua data user
        {
            if (user.Count > 0)
            {
                Console.WriteLine("List of user:");

                foreach (UserModel user in user)
                {
                    ShowUser(user);
                }
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("User is empty");
                Console.WriteLine("Create user first, choose 3 for back");
                Console.WriteLine("================================");
            }
        }

        public UserModel SearchUser(string username) //Method untuk search data user berdasarkan inputan string username
        {
            UserModel foundUser = user.FirstOrDefault(u => u.Username == username);

            if (user.Contains(foundUser))
            {
                Console.WriteLine($"User {username} was found");
                Console.WriteLine("================================");
                Console.WriteLine($"ID: {foundUser.ID}");
                Console.WriteLine($"Name: {foundUser.FirstName} {foundUser.LastName}");
                Console.WriteLine($"Username: {foundUser.Username}");
                Console.WriteLine($"Password: {foundUser.Password}");
                Console.WriteLine("================================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine($"User {username} not found");
                Console.WriteLine("================================");

            }
            return foundUser;
        }

        public bool LoginUser(string username, string password) // Method login user 
        {
            UserModel foundUser = user.FirstOrDefault(u => u.Username == username);

            if (foundUser != null && foundUser.Password == password) // kondisi jika username dan password cocok
            {
                Console.WriteLine("================================");
                Console.WriteLine("Login Succesfull.");
                Console.WriteLine("================================");
                return true;
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("Username or password is invalid.");
                Console.WriteLine("================================");
                return false;
            }
        }



        //Method Tambahan
        private string GenerateUsername(string firstName, string lastName) // Method untuk generateusername
        {
            string firstTwoLetters = firstName.Substring(0, 2);
            string lastTwoLetters = lastName.Substring(0, 2);
            return $"{firstTwoLetters}{lastTwoLetters}";
        }

        
        private bool IsValidPassword(string password) //Method untuk cek password yang dimasukkan harus sesuai aturan
        {
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUppercase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasUppercase && hasDigit)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
