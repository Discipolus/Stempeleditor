using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//nvda screenreader

namespace Engine.Storage
{
    public static class Storage
    {
        #region Properties
        static string server = "";
        static string database = "";
        static string? user = "";
        static string? password = "";
        #endregion

        public static void connect()
        {

            string connectionString = $"Server={server};Database={database};Authentication=Actice Directory Integrated;";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Database connection opened successfully");
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Failed in opening a Database connection via Active Directory authentification");
                Console.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.ToString());
                Console.WriteLine("Trying to connect via username and password");

                try
                {
                    Console.WriteLine("username: ");
                    user = Console.ReadLine();
                    Console.WriteLine("password: ");
                    password = Console.ReadLine();
                    connectionString = $"Server={server};Database={database};Authentication=SqlPassword;User ID={user};Password={password}";
                    connection = new SqlConnection(connectionString);

                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Failed in opening a Database connection via username/password");
                    Console.WriteLine(ex2.Message);
                    Console.Error.WriteLine(ex2.ToString());
                }

            }
        }
    }
}
