using AuthenticationApp.Model;
using AuthenticationApp.System;
using System.Runtime.CompilerServices;

namespace AuthenticationApp
{
    public class Program
    {
        private static Authentication authentication;
        static void Main(string[] args)
        {
            authentication = new Authentication();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Exit");
                string menuOption = Console.ReadLine();

                Console.WriteLine();

                switch (menuOption)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ShowUser();
                        break;
                    case "3":
                        SearchUser();
                        break;
                    case "4":
                        LoginUser();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Your option is not valid");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void CreateUser()
        {
            authentication.CreateUserFromInput();
        }

        private static void ShowUser()
        {

            authentication.ShowAllUsers();

            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    EditUser();
                    break;
                case "2":
                    DeleteUser();
                    break;
                case "3":
                    // Kembali ke menu utama
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

        private static void EditUser()
        {
            Console.WriteLine("Enter ID you want to edit : ");
            int userID = Convert.ToInt32(Console.ReadLine());
            authentication.EditUser(userID);
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter ID you want to delete : ");
            int userID = Convert.ToInt32(Console.ReadLine());

            authentication.DeleteUser(userID);
        }

        private static void SearchUser()
        {
            Console.WriteLine("Enter username want you want to find : ");
            string username = Console.ReadLine();

            authentication.SearchUser(username);
        }

        private static void LoginUser()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            authentication.LoginUser(username, password);
        }
    }
}
