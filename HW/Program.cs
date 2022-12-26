using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace HW
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User[] users = new User[3];

            DateTime aDate = DateTime.Now;
           // aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss");


            users[0] = new User("Abbas", "Dajweoi1", "Monday, 20 April 2022 12:00:05");
            users[1] = new User("Hikmet", "A2opkoi1", "Friday, 23 May 2022 15:00:05");
            users[2] = new User("Ali", "23Fikswe", "Sunday, 30 July 2022 10:00:05");


            string input;
            bool check = false;

            do
            {
                Console.WriteLine("\n1.User əlavə et");
                Console.WriteLine("2.Userlere bax");
                Console.WriteLine("3.Userler üzrə axtarış et");

                input = Console.ReadLine();

                if (input == "1")
                {
                    string name;
                    
                    do
                    {
                        Console.WriteLine("Username daxil edin: ");
                        name = Console.ReadLine();

                        if (!IsUserName(name))
                        {
                            Console.WriteLine("Username min 8, max 25 deyerden ibaret olmalidi!");
                            check = true;
                        }

                    } while (check);

                    string pass;

                    do
                    {
                        Console.WriteLine("Pass daxil edin: ");
                        pass = Console.ReadLine();

                        if (!HasDigit(pass))
                        {
                            check = true;
                        }

                        else if (!HasLower(pass))
                        {
                            check = true;
                        }
                        else if (!HasUpper(pass))
                        {
                            check = true;
                        }

                    } while (check);


                    User user = new User(name, pass, aDate);

                    Array.Resize(ref users, users.Length + 1);
                    users[users.Length - 1] = user;

                }
                else if (input == "2")
                {
                    for (int i = 0; i < users.Length; i++)
                    {
                        Console.WriteLine(users[i].Showinfo());
                    }
                }

                else if ( input == "3")
                {
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    string find = Console.ReadLine();

                    var filter = searchUser(users, find);
                    ShowUsersInfo(filter);

                }

            } while (input != "1" || input!="2" || input!="3");
        }


        static User[] searchUser(User[] arr, string find)
        {
            User[] newArr = new User[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].UserName.Contains(find, StringComparison.OrdinalIgnoreCase))
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = arr[i];
                }
            }
            return newArr;
        }

        static void ShowUsersInfo(User[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].Showinfo());
            }
        }

        static bool IsUserName(string name)
        {

            if (name.Length < 6)
            {
                return false;
            }
            return true;
        }

        static bool HasDigit(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {

                if (!char.IsDigit(pass[i]))
                {
                    Console.WriteLine("Pass-de min 1 reqem olmalidi");
                    return false;
                }
            }
            return true;
        }

        static bool HasUpper(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {

                if (!char.IsUpper(pass[i]))
                {
                    Console.WriteLine("Pass-da min 1 boyuk herf olmalidi");
                    return false;
                }
            }

            return true;
        }


        static bool HasLower(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {

                if (!char.IsLower(pass[i]))
                {
                    Console.WriteLine("Pass-da min 1 kicik herf olmalidi");
                    return false;
                }
            }
            return true;
        }
    }
}
