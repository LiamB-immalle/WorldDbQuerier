using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.1";

        static void ConnectSql()
        {

        }

        static void CountryAmount()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
            "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            conn.Open();

            Console.WriteLine("Amount o' country's : {0}", cmd.ExecuteScalar());

            conn.Close();
        }

        static void PrintCountry()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
            "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM world.Country";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine((string)reader["Name"]);
            }

            reader.Dispose();
            conn.Close();
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Console.WriteLine("Versie {0}", version);
                        break;
                    default:
                        Console.WriteLine("Onbekend argument");
                        break;
                }
            }

            Console.WriteLine("[1] to print all countries");
            Console.WriteLine("[2] to print the amount of countries");
            Console.WriteLine("everything else to quit");

            string n = Console.ReadLine();

            if (n == "1")
            {
                PrintCountry();
            }
            else if (n == "2")
            {
                CountryAmount();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}