using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    public class MySQL
    {
        public static string connectionString = "server=localhost;user=root;database=elliprojekt;port=3306;password=gotmilk1";

        public static void StartSQL()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                // Perform database operations

                string sql = "SELECT * FROM products";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " - Name: " + rdr[1] + " - SKU: " + rdr[2]);
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }


        public static void FindCategories()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                // Perform database operations

                string sql = "SELECT id, name FROM `groups`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " - " + rdr[1]);
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        public static void FindCategory(int category)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Getting products...");
                Console.ResetColor();
                int chosenCategory = category;
                conn.Open();
                // Perform database operations

                string sql = "getProductsForCat";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cat", chosenCategory);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("These are all the products from that category.");
                    Console.ResetColor();
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no products for that category.");
                    Console.ResetColor();
                }
                
                while (rdr.Read())
                {
                    Console.WriteLine("Name: " + rdr[3] + " - SKU: " + rdr[4]);
                }
                
                rdr.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            
        }

        public static void FindBySKU(string SKU)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                // Perform database operations

                string sql = "GetProductBySKU";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@abc", SKU);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("This is the item with that SKU " + SKU + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No such item exists.");
                    Console.ResetColor();
                }

                while (rdr.Read())
                {
                    Console.WriteLine("Name: " + rdr[1] + " - SKU: " + rdr[2]);
                }

                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }
    }
}
