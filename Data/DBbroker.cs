using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace HospitalSystem.Data
{
    // Abstract class representing a database broker
    public abstract class DBbroker
    {
        // OracleConnection to manage the connection to the database
        OracleConnection connection;

        // Constructor to initialize the database connection
        public DBbroker()
        {
            Initialize();
        }

        // Method to initialize the Oracle database connection
        private void Initialize()
        {
            // Database connection parameters
            string serverName = "ryan";
            string database = "XE";
            string userName = "health_schema";
            string password = "0123456";

            // Construct the Oracle connection string
            string ConnectionString = $"User Id={userName};Password={password};Data Source={serverName}/{database};";

            // Create a new OracleConnection using the connection string
            connection = new OracleConnection(ConnectionString);
        }

        // Method to open the database connection
        protected bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                CloseConnection();
                return false;
            }
        }

        // Method to close the database connection
        protected bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method to execute a SELECT query and retrieve data from the database
        protected List<List<string>> Get(string query)
        {
            List<List<string>> list = new List<List<string>>();

            // Open the database connection
            if (OpenConnection() == true)
            {
                // Create an OracleCommand with the query and the open connection
                OracleCommand cmd = new OracleCommand(query, connection);
                // Execute the query and get the OracleDataReader
                OracleDataReader reader = cmd.ExecuteReader();

                // Read data from the reader and populate the list
                while (reader.Read())
                {
                    List<string> row = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader[i].ToString());
                    }
                    list.Add(row);
                }

                // Close the database connection
                CloseConnection();
            }

            return list;
        }

        // Method to execute a non-query (e.g., INSERT, UPDATE, DELETE) command on the database
        protected void Command(string query)
        {
            // Open the database connection
            if (OpenConnection() == true)
            {
                // Create an OracleCommand with the query and the open connection
                OracleCommand cmd = new OracleCommand(query, connection);
                // Execute the command and get the number of rows affected
                int rowsAffected = cmd.ExecuteNonQuery();

                // Display success or failure based on the number of rows affected
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Successful");
                }
                else
                {
                    Console.WriteLine("Failed");
                }

                // Close the database connection
                connection.Close();
            }
        }
    }
}
