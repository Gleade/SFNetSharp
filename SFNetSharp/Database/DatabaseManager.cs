using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SFNetSharp.Database
{
    class DatabaseManager
    {
        static MySqlConnection MySqlConn { get; set; }
        static string MySQLConnectionString { get; set; } = "server=localhost;database=testdb;uid=root;pwd=password;";

        /// <summary>
        /// Connect to a MYSQL database.
        /// </summary>
        /// <param name="host">The IP address for the host of the database e.g localhost.</param>
        /// <param name="database">The name of the database on that host you wish to use.</param>
        /// <param name="username">The username for the database.</param>
        /// <param name="pass">The password for the database.</param>
        public static void Connect(string host, string database, string username, string pass)
        {
            MySQLConnectionString = String.Format("server={0};uid={1};pwd={2};database={3};", host, username, pass, database);
        
            try
            {
                MySqlConn = new MySqlConnection(MySQLConnectionString);
                MySqlConn.Open();
                Console.WriteLine("Connected to DB: " + MySQLConnectionString);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to connect to DB: " + MySQLConnectionString);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Run a query against the database.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A table that you can retreive data from by using the column name.</returns>
        public static Table RunQuery(string query)
        {
            MySqlDataReader reader = ExecuteQuery(query);
            Table newTable = null;

            if (reader != null)
            {
                newTable = new Table(reader);
            }

            return newTable;
        }

        /// <summary>
        /// Disconnect / close the connection to the database.
        /// </summary>
        public static void Disconnect()
        {
            MySqlConn.Close();
        }


        private static MySqlDataReader ExecuteQuery(string query)
        {
            // Execute a command
            MySqlCommand command = new MySqlCommand();
            MySqlDataReader reader = null;
            command.CommandText = query;
            command.Connection = MySqlConn;
            // Return a reader to begin reading
            try
            {
                reader = command.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine("ExecuteQuery exception: " + ex.StackTrace);
            }



            return reader;

        }
    }
}
