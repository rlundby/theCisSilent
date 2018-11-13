using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("{0}. {1} by {2}", AppInfo.appName, AppInfo.appVersion, AppInfo.appAuthor);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome friendly user!");
            Console.WriteLine("What would you like to do today?");
            Console.ResetColor();

            Console.WriteLine("1: Find products by Category.");
            Console.WriteLine("2: Find products by SKU.");
            Console.WriteLine("3: Get all Products.");

            string answer = Console.ReadLine();
            int number = Int32.Parse(answer);

            switch (number)
            {
                case 1:
                    Console.WriteLine("Lets find you categories");
                    MySQLHandler.GetAllCategories();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Do you want a list of SKU or enter a SKU?");
                    Console.ResetColor();

                    Console.WriteLine("1: Enter SKU-number");
                    Console.WriteLine("2: List all SKU-numbers");
                    string response = Console.ReadLine();
                    int res = Int32.Parse(response);
                    switch(res)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Please enter your SKU-number:");
                            Console.ResetColor();

                            string SKU = Console.ReadLine();
                            MySQLHandler.GetProductBySKU(SKU);
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Here are all products with SKU:");
                            Console.ResetColor();

                            MySQLHandler.GetAllProducts();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a correct number.");
                            Console.ResetColor();
                            HelperClass.EndOfApp();
                            break;
                    }
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You're getting ALL products!");
                    Console.ResetColor();

                    MySQLHandler.GetAllProducts();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please. That's not a valid number. :(");
                    Console.ResetColor();
                    HelperClass.EndOfApp();
                    break;
            }

            
        }
    }

    class AppInfo
    {
       public static string appName = "Get Products";
       public static string appVersion = "Version 1.0";
       public static string appAuthor = "Rickard Lundby";
    }

    class MySQLHandler
    {
        public static void GetAllProducts()
        {
            MySQL.StartSQL();
            HelperClass.EndOfApp();
        }
        public static void GetAllCategories()
        {
            MySQL.FindCategories();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Which category would you like?");
            Console.ResetColor();

            string answer = Console.ReadLine();
            int category = Int32.Parse(answer);
            MySQL.FindCategory(category);
            HelperClass.EndOfApp();

        }
        public static void GetProductBySKU(string SKU)
        {
            MySQL.FindBySKU(SKU);
            HelperClass.EndOfApp();
        }
    }

    class HelperClass
    {
        public static void EndOfApp()
        {
            Console.WriteLine("Would you like to try again?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter START to try again.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter EXIT to give up.");
            Console.ResetColor();

             string ans = Console.ReadLine();
            string lowerAns = ans.ToLower();
            switch (lowerAns)
            {
                case "start":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YESSS! Buckle up, here we go again!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("##############################");
                    Console.ResetColor();
                    Program.Main();
                    break;
                case "exit":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" :( bye ");
                    Console.ResetColor();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You didn't write START or EXIT - so I'm going to assume you wanna keep going!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("##############################");
                    Console.ResetColor();
                    Program.Main();
                    break;

            }
         }
    }
}
