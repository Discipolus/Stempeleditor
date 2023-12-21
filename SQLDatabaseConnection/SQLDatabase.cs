using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IStorage;
using System.Data;
using System.Data.SqlClient;

namespace SQLDatabaseConnection
{
    public class SQLDatabase : IStorageService
    {
        #region Properties
        private readonly string server = "localhost";
        private readonly string database = "StempelDatabase";
        private readonly string tablename = "Stempelverfuegungen";
        private string? user = "";
        private string? password = "";

        private string connectionString;
        private SqlConnection? connection;
        #endregion
        public SQLDatabase()
        {
            //connectionString = $"Server={server};Database={database};Authentication=Active Directory Integrated";             
            connectionString = $"Server={server};Database={database};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void connect()
        {
            try
            {
                connection!.Open();
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
                    throw new Exception("Failed in opening a Database connection");
                }

            }
        }

        public string? ladeStempel(Guid guid)
        {
            connect();
            SqlCommand command = new SqlCommand($"SELECT * FROM {tablename} WHERE ID = '{guid.ToString()}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            string? returnvalue = dt.Rows[0]["Stempel"].ToString();
            connection!.Close();
            return returnvalue;
        }

        public void speicherStempel(string stempel, Guid guid, string stempelName)
        {
            connect();
            SqlCommand command = new SqlCommand($"SELECT * FROM {tablename} WHERE ID = '{guid.ToString()}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            if (dt.Rows.Count == 0)
            {
                command = new SqlCommand($"INSERT INTO {tablename} VALUES ('{guid.ToString()}','{stempelName}','{stempel}');", connection);
            }
            else
            {
                command = new SqlCommand($"UPDATE {tablename} SET Stempel = '{stempel}', Name = '{stempelName}' WHERE ID = '{guid.ToString()}'", connection);
            }
            command.ExecuteNonQuery();
            connection!.Close();
        }

        public List<string> ladeStempelListe()
        {
            connect();
            SqlCommand command = new SqlCommand($"SELECT * FROM {tablename}", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<string> stempelListe = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                stempelListe.Add(row["Stempel"].ToString());
            }
            connection!.Close();

            return stempelListe;
        }
    }
}
