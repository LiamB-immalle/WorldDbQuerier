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
        }

        static void PrintCountry()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
            "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Name FROM world.Country";
            
            conn.Open();

            Console.WriteLine("");
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

            PrintCountry();
            
        }
    }
}